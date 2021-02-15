namespace OpenTelemetry.Instrumentation.Tagging
{
    internal interface IHasStatusCode
    {
        string HttpStatusCode { get; set; }
    }
}
