using OpenTelemetry.Instrumentation.DuckTyping;

namespace Datadog.Trace.DuckTyping.Tests.Fields.TypeChaining.ProxiesDefinitions
{
    public interface IObscureStaticReadonlyErrorDuckType
    {
        [Duck(Name = "_publicStaticReadonlySelfTypeField", Kind = DuckKind.Field)]
        IDummyFieldObject PublicStaticReadonlySelfTypeField { get; set; }
    }
}
