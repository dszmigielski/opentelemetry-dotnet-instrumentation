using System;
using System.Net;

namespace OpenTelemetry.Instrumentation.Agent.Transports
{
    internal class ApiWebRequestFactory : IApiRequestFactory
    {
        public string Info(Uri endpoint)
        {
            return endpoint.ToString();
        }

        public IApiRequest Create(Uri endpoint)
        {
            return new ApiWebRequest(WebRequest.CreateHttp(endpoint));
        }
    }
}
