//------------------------------------------------------------------------------
// <auto-generated />
// This file was automatically generated by the UpdateVendors tool.
//------------------------------------------------------------------------------
using System;

namespace OpenTelemetry.Instrumentation.Vendors.StatsdClient
{
    /// <summary>
    /// IDogStatsd is an interface over DogStatsdService.
    /// </summary>
    internal interface IDogStatsd : IDisposable
    {
        /// <summary>
        /// Gets the telemetry counters
        /// </summary>
        /// <value>The telemetry counters.</value>
        ITelemetryCounters TelemetryCounters { get; }

        /// <summary>
        /// Configures the instance.
        /// Must be called before any other methods.
        /// </summary>
        /// <param name="config">The value of the config.</param>
        void Configure(StatsdConfig config);

        /// <summary>
        /// Adjusts the specified counter by a given delta.
        /// </summary>
        /// <param name="statName">The name of the metric.</param>
        /// <param name="value">A given delta.</param>
        /// <param name="sampleRate">Percentage of metric to be sent.</param>
        /// <param name="tags">Array of tags to be added to the data.</param>
        void Counter(string statName, double value, double sampleRate = 1, string[] tags = null);

        /// <summary>
        /// Decrements the specified counter.
        /// </summary>
        /// <param name="statName">The name of the metric.</param>
        /// <param name="value">The amount of decrement.</param>
        /// <param name="sampleRate">Percentage of metric to be sent.</param>
        /// <param name="tags">Array of tags to be added to the data.</param>
        void Decrement(string statName, int value = 1, double sampleRate = 1, params string[] tags);

        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="title">The title of the event.</param>
        /// <param name="text">The text body of the event.</param>
        /// <param name="alertType">error, warning, success, or info (defaults to info).</param>
        /// <param name="aggregationKey">A key to use for aggregating events.</param>
        /// <param name="sourceType">The source type name.</param>
        /// <param name="dateHappened">The epoch timestamp for the event (defaults to the current time from the DogStatsD server).</param>
        /// <param name="priority">Specifies the priority of the event (normal or low).</param>
        /// <param name="hostname">The name of the host.</param>
        /// <param name="tags">Array of tags to be added to the data.</param>
        void Event(
            string title,
            string text,
            string alertType = null,
            string aggregationKey = null,
            string sourceType = null,
            int? dateHappened = null,
            string priority = null,
            string hostname = null,
            string[] tags = null);

        /// <summary>
        /// Records the latest fixed value for the specified named gauge.
        /// </summary>
        /// <param name="statName">The name of the metric.</param>
        /// <param name="value">The value of the gauge.</param>
        /// <param name="sampleRate">Percentage of metric to be sent.</param>
        /// <param name="tags">Array of tags to be added to the data.</param>
        void Gauge(string statName, double value, double sampleRate = 1, string[] tags = null);

        /// <summary>
        /// Records a value for the specified named histogram.
        /// </summary>
        /// <param name="statName">The name of the metric.</param>
        /// <param name="value">The value of the histogram.</param>
        /// <param name="sampleRate">Percentage of metric to be sent.</param>
        /// <param name="tags">Array of tags to be added to the data.</param>
        void Histogram(string statName, double value, double sampleRate = 1, string[] tags = null);

        /// <summary>
        /// Records a value for the specified named distribution.
        /// </summary>
        /// <param name="statName">The name of the metric.</param>
        /// <param name="value">The value of the distribution.</param>
        /// <param name="sampleRate">Percentage of metric to be sent.</param>
        /// <param name="tags">Array of tags to be added to the data.</param>
        void Distribution(string statName, double value, double sampleRate = 1, string[] tags = null);

        /// <summary>
        /// Increments the specified counter.
        /// </summary>
        /// <param name="statName">The name of the metric.</param>
        /// <param name="value">The amount of increment.</param>
        /// <param name="sampleRate">Percentage of metric to be sent.</param>
        /// <param name="tags">Array of tags to be added to the data.</param>
        void Increment(string statName, int value = 1, double sampleRate = 1, string[] tags = null);

        /// <summary>
        /// Records a value for the specified set.
        /// </summary>
        /// <param name="statName">The name of the metric.</param>
        /// <param name="value">The value to set.</param>
        /// <param name="sampleRate">Percentage of metric to be sent.</param>
        /// <param name="tags">Array of tags to be added to the data.</param>
        /// <typeparam name="T">The type of the value.</typeparam>
        void Set<T>(string statName, T value, double sampleRate = 1, string[] tags = null);

        /// <summary>
        /// Records a value for the specified set.
        /// </summary>
        /// <param name="statName">The name of the metric.</param>
        /// <param name="value">The value to set.</param>
        /// <param name="sampleRate">Percentage of metric to be sent.</param>
        /// <param name="tags">Array of tags to be added to the data.</param>
        void Set(string statName, string value, double sampleRate = 1, string[] tags = null);

        /// <summary>
        /// Creates a timer that records the execution time until Dispose is called on the returned value.
        /// </summary>
        /// <param name="name">The name of the metric.</param>
        /// <param name="sampleRate">Percentage of metric to be sent.</param>
        /// <param name="tags">Array of tags to be added to the data.</param>
        /// <returns>A disposable object that records the execution time until Dispose is called.</returns>
        IDisposable StartTimer(string name, double sampleRate = 1, string[] tags = null);

        /// <summary>
        /// Records an execution time for the given action.
        /// </summary>
        /// <param name="action">The given action.</param>
        /// <param name="statName">The name of the metric.</param>
        /// <param name="sampleRate">Percentage of metric to be sent.</param>
        /// <param name="tags">Array of tags to be added to the data.</param>
        void Time(Action action, string statName, double sampleRate = 1, string[] tags = null);

        /// <summary>
        /// Records an execution time for the given function.
        /// </summary>
        /// <param name="func">The given function.</param>
        /// <param name="statName">The name of the metric.</param>
        /// <param name="sampleRate">Percentage of metric to be sent.</param>
        /// <param name="tags">Array of tags to be added to the data.</param>
        /// <typeparam name="T">The type of the returned value of <paramref name="func"/>.</typeparam>
        /// <returns>The returned value of <paramref name="func"/>.</returns>
        T Time<T>(Func<T> func, string statName, double sampleRate = 1, string[] tags = null);

        /// <summary>
        /// Records an execution time in milliseconds.
        /// </summary>
        /// <param name="statName">The name of the metric.</param>
        /// <param name="value">The time in millisecond.</param>
        /// <param name="sampleRate">Percentage of metric to be sent.</param>
        /// <param name="tags">Array of tags to be added to the data.</param>
        void Timer(string statName, double value, double sampleRate = 1, string[] tags = null);

        /// <summary>
        /// Records a run status for the specified named service check.
        /// </summary>
        /// <param name="name">The name of the service check.</param>
        /// <param name="status">A constant describing the service status.</param>
        /// <param name="timestamp">The epoch timestamp for the service check (defaults to the current time from the DogStatsD server).</param>
        /// <param name="hostname">The hostname to associate with the service check.</param>
        /// <param name="tags">Array of tags to be added to the data.</param>
        /// <param name="message">Additional information or a description of why the status occurred.</param>
        void ServiceCheck(
            string name,
            Status status,
            int? timestamp = null,
            string hostname = null,
            string[] tags = null,
            string message = null);
    }
}
