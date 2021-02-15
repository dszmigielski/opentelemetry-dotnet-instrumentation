namespace OpenTelemetry.Instrumentation
{
    /// <summary>
    /// Interface for scope getter and setter access
    /// </summary>
    internal interface IScopeRawAccess
    {
        Scope Active { get; set; }
    }
}
