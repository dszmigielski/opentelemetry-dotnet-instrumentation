#if NETFRAMEWORK

using System;
using System.Net;
using OpenTelemetry.Instrumentation.Headers;

namespace OpenTelemetry.Instrumentation.ExtensionMethods
{
    /// <summary>
    /// Extension methods for <see cref="WebHeaderCollection"/> objects.
    /// </summary>
    internal static class WebHeadersExtensions
    {
        /// <summary>
        /// Provides an <see cref="IHeadersCollection"/> implementation that wraps the specified <see cref="WebHeaderCollection"/>.
        /// </summary>
        /// <param name="headers">The Web headers to wrap.</param>
        /// <returns>An object that implements <see cref="IHeadersCollection"/>.</returns>
        public static IHeadersCollection Wrap(this WebHeaderCollection headers)
        {
            if (headers == null)
            {
                throw new ArgumentNullException(nameof(headers));
            }

            return new WebHeadersCollection(headers);
        }
    }
}

#endif
