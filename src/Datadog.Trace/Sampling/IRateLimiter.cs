namespace OpenTelemetry.Instrumentation.Sampling
{
    internal interface IRateLimiter
    {
        bool Allowed(Span span);

        float GetEffectiveRate();
    }
}
