using System;

namespace OpenTelemetry.Instrumentation.Agent
{
    internal interface IApiRequestFactory
    {
        string Info(Uri endpoint);

        IApiRequest Create(Uri endpoint);
    }
}
