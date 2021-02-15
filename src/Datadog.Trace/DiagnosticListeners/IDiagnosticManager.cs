namespace OpenTelemetry.Instrumentation.DiagnosticListeners
{
    internal interface IDiagnosticManager
    {
        void Start();

        void Stop();
    }
}
