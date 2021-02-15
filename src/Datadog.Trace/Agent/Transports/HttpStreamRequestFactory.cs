using System;
using OpenTelemetry.Instrumentation.HttpOverStreams;

namespace OpenTelemetry.Instrumentation.Agent.Transports
{
    internal class HttpStreamRequestFactory : IApiRequestFactory
    {
        private readonly IStreamFactory _streamFactory;
        private readonly DatadogHttpClient _httpClient;

        public HttpStreamRequestFactory(IStreamFactory streamFactory, DatadogHttpClient httpClient)
        {
            _streamFactory = streamFactory;
            _httpClient = httpClient;
        }

        public string Info(Uri endpoint)
        {
            return $"{_streamFactory.Info()} to {endpoint}";
        }

        public IApiRequest Create(Uri endpoint)
        {
            return new HttpStreamRequest(_httpClient, endpoint, _streamFactory);
        }
    }
}
