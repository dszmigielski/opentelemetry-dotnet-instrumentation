using System;
using System.Collections.Generic;
using OpenTelemetry.Instrumentation.Abstractions;

namespace Datadog.Trace.TestHelpers
{
    public class TestSpan : ISpan
    {
        public string ResourceName { get; set; }

        public string Type { get; set; }

        public bool Error { get; set; }

        private Dictionary<string, string> Tags { get; } = new Dictionary<string, string>();

        ISpan ISpan.SetTag(string key, string value)
        {
            SetTagInternal(key, value);

            return this;
        }

        public string GetTag(string key)
            => Tags.TryGetValue(key, out var tagValue)
                   ? tagValue
                   : null;

        public void SetException(Exception exception)
        {
            Error = true;

            SetTagInternal(OpenTelemetry.Instrumentation.Tags.ErrorMsg, exception.Message);
            SetTagInternal(OpenTelemetry.Instrumentation.Tags.ErrorStack, exception.StackTrace);
            SetTagInternal(OpenTelemetry.Instrumentation.Tags.ErrorType, exception.GetType().ToString());
        }

        private void SetTagInternal(string key, string value)
        {
            if (value == null)
            {
                Tags.Remove(key);
            }
            else
            {
                Tags[key] = value;
            }
        }
    }
}
