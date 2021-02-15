using OpenTelemetry.Instrumentation.Vendors.MessagePack;
using OpenTelemetry.Instrumentation.Vendors.MessagePack.Formatters;
using OpenTelemetry.Instrumentation.Vendors.MessagePack.Resolvers;

namespace OpenTelemetry.Instrumentation.Agent.MessagePack
{
    internal class SpanFormatterResolver : IFormatterResolver
    {
        public static readonly IFormatterResolver Instance = new SpanFormatterResolver();

        private static readonly IMessagePackFormatter<Span> Formatter = new SpanMessagePackFormatter();

        private SpanFormatterResolver()
        {
        }

        public IMessagePackFormatter<T> GetFormatter<T>()
        {
            if (typeof(T) == typeof(Span))
            {
                return (IMessagePackFormatter<T>)Formatter;
            }

            return StandardResolver.Instance.GetFormatter<T>();
        }
    }
}
