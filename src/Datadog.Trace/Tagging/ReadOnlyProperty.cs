using System;

namespace OpenTelemetry.Instrumentation.Tagging
{
    internal class ReadOnlyProperty<TTags, TResult> : Property<TTags, TResult>
    {
        public ReadOnlyProperty(string key, Func<TTags, TResult> getter)
            : base(key, getter, (_, _) => { })
        {
        }

        public override bool IsReadOnly => true;
    }
}
