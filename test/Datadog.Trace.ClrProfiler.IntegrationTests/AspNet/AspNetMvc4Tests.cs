#if NET461
#pragma warning disable SA1402 // File may only contain a single class
#pragma warning disable SA1649 // File name must match first type name

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Datadog.Trace.ClrProfiler.IntegrationTests
{
    [Collection("IisTests")]
    public class AspNetMvc4TestsCallsite : AspNetMvc4Tests
    {
        public AspNetMvc4TestsCallsite(IisFixture iisFixture, ITestOutputHelper output)
            : base(iisFixture, output, enableCallTarget: false, enableInlining: false)
        {
        }
    }

    [Collection("IisTests")]
    public class AspNetMvc4TestsCallTargetNoInlining : AspNetMvc4Tests
    {
        public AspNetMvc4TestsCallTargetNoInlining(IisFixture iisFixture, ITestOutputHelper output)
            : base(iisFixture, output, enableCallTarget: true, enableInlining: false)
        {
        }
    }

    [Collection("IisTests")]
    public class AspNetMvc4TestsCallTarget : AspNetMvc4Tests
    {
        public AspNetMvc4TestsCallTarget(IisFixture iisFixture, ITestOutputHelper output)
            : base(iisFixture, output, enableCallTarget: true, enableInlining: true)
        {
        }
    }

    public abstract class AspNetMvc4Tests : TestHelper, IClassFixture<IisFixture>
    {
        private readonly IisFixture _iisFixture;

        public AspNetMvc4Tests(IisFixture iisFixture, ITestOutputHelper output, bool enableCallTarget, bool enableInlining)
            : base("AspNetMvc4", @"test\test-applications\aspnet", output)
        {
            SetServiceVersion("1.0.0");
            SetCallTargetSettings(enableCallTarget, enableInlining);

            _iisFixture = iisFixture;
            _iisFixture.TryStartIis(this);
        }

        public static TheoryData<string, string, HttpStatusCode, bool, string, string, Dictionary<string, string>> Data =>
            new()
            {
                { "/Admin/Home/Index", "GET /admin/home/index", HttpStatusCode.OK, false, null, null, AdminHomeIndexTags() },
                { "/Home/Index", "GET /home/index", HttpStatusCode.OK, false, null, null, HomeIndexTags() },
                { "/Home/BadRequest", "GET /home/badrequest", HttpStatusCode.InternalServerError, true, null, null, BadRequestTags() },
                { "/Home/StatusCode?value=201", "GET /home/statuscode", HttpStatusCode.Created, false, null, null, StatusCodeTags() },
                { "/Home/StatusCode?value=503", "GET /home/statuscode", HttpStatusCode.ServiceUnavailable, true, null, "The HTTP response has status code 503.", StatusCodeTags() },
            };

        [Theory]
        [Trait("Category", "EndToEnd")]
        [Trait("Integration", nameof(Integrations.AspNetMvcIntegration))]
        [MemberData(nameof(Data))]
        public async Task SubmitsTraces(
            string path,
            string expectedResourceName,
            HttpStatusCode expectedStatusCode,
            bool isError,
            string expectedErrorType,
            string expectedErrorMessage,
            Dictionary<string, string> tags)
        {
            await AssertWebServerSpan(
                path,
                _iisFixture.Agent,
                _iisFixture.HttpPort,
                expectedStatusCode,
                isError,
                expectedErrorType,
                expectedErrorMessage,
                "web",
                "aspnet-mvc.request",
                expectedResourceName,
                "1.0.0",
                tags);
        }

        private static Dictionary<string, string> AdminHomeIndexTags() =>
            new Dictionary<string, string>
            {
                { Tags.AspNetRoute, "Admin/{controller}/{action}/{id}" },
                { Tags.AspNetController, "home" },
                { Tags.AspNetAction, "index" },
                { Tags.AspNetArea, "admin" }
            };

        private static string DefaultRoute() => "{controller}/{action}/{id}";

        private static Dictionary<string, string> HomeIndexTags() =>
            new Dictionary<string, string>
            {
                { Tags.AspNetRoute, DefaultRoute() },
                { Tags.AspNetController, "home" },
                { Tags.AspNetAction, "index" }
            };

        private static Dictionary<string, string> BadRequestTags() =>
            new Dictionary<string, string>
            {
                { Tags.AspNetRoute, DefaultRoute() },
                { Tags.AspNetController, "home" },
                { Tags.AspNetAction, "badrequest" }
            };

        private static Dictionary<string, string> StatusCodeTags() =>
            new Dictionary<string, string>
            {
                { Tags.AspNetRoute, DefaultRoute() },
                { Tags.AspNetController, "home" },
                { Tags.AspNetAction, "statuscode" }
            };
    }
}

#endif
