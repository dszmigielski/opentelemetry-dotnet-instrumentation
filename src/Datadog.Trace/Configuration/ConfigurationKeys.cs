namespace Datadog.Trace.Configuration
{
    /// <summary>
    /// String constants for standard Datadog configuration keys.
    /// </summary>
    public static class ConfigurationKeys
    {
        /// <summary>
        /// Configuration key for the path to the configuration file.
        /// Can only be set with an environment variable
        /// or in the <c>app.config</c>/<c>web.config</c> file.
        /// </summary>
        public const string ConfigurationFileName = "OTEL_TRACE_CONFIG_FILE";

        /// <summary>
        /// Configuration key for the application's environment. Sets the "env" tag on every <see cref="Span"/>.
        /// </summary>
        /// <seealso cref="TracerSettings.Environment"/>
        public const string Environment = "OTEL_ENV";

        /// <summary>
        /// Configuration key for the application's default service name.
        /// Used as the service name for top-level spans,
        /// and used to determine service name of some child spans.
        /// </summary>
        /// <seealso cref="TracerSettings.ServiceName"/>
        public const string ServiceName = "OTEL_SERVICE";

        /// <summary>
        /// Configuration key for the application's version. Sets the "version" tag on every <see cref="Span"/>.
        /// </summary>
        /// <seealso cref="TracerSettings.ServiceVersion"/>
        public const string ServiceVersion = "OTEL_VERSION";

        /// <summary>
        /// Configuration key for enabling or disabling the Tracer.
        /// Default is value is true (enabled).
        /// </summary>
        /// <seealso cref="TracerSettings.TraceEnabled"/>
        public const string TraceEnabled = "OTEL_TRACE_ENABLED";

        /// <summary>
        /// Configuration key for enabling or disabling the Tracer's debug mode.
        /// Default is value is false (disabled).
        /// </summary>
        /// <seealso cref="TracerSettings.DebugEnabled"/>
        public const string DebugEnabled = "OTEL_TRACE_DEBUG";

        /// <summary>
        /// Configuration key for a list of integrations to disable. All other integrations remain enabled.
        /// Default is empty (all integrations are enabled).
        /// Supports multiple values separated with semi-colons.
        /// </summary>
        /// <seealso cref="TracerSettings.DisabledIntegrationNames"/>
        public const string DisabledIntegrations = "OTEL_DISABLED_INTEGRATIONS";

        /// <summary>
        /// Configuration key for a list of AdoNet types that will be excluded from automatic instrumentation.
        /// Default is empty (all AdoNet types are included in automatic instrumentation).
        /// Supports multiple values separated with semi-colons.
        /// </summary>
        /// <seealso cref="TracerSettings.AdoNetExcludedTypes"/>
        public const string AdoNetExcludedTypes = "OTEL_TRACE_ADONET_EXCLUDED_TYPES";

        /// <summary>
        /// Configuration key for the Agent host where the Tracer can send traces.
        /// Overridden by <see cref="AgentUri"/> if present.
        /// Default value is "localhost".
        /// </summary>
        /// <seealso cref="TracerSettings.AgentUri"/>
        public const string AgentHost = "OTEL_AGENT_HOST";

        /// <summary>
        /// Configuration key for the Agent port where the Tracer can send traces.
        /// Default value is 8126.
        /// </summary>
        /// <seealso cref="TracerSettings.AgentUri"/>
        public const string AgentPort = "OTEL_TRACE_AGENT_PORT";

        /// <summary>
        /// Configuration key for the named pipe where the Tracer can send traces.
        /// Default value is <c>null</c>.
        /// </summary>
        /// <seealso cref="TracerSettings.TracesPipeName"/>
        public const string TracesPipeName = "OTEL_TRACE_PIPE_NAME";

        /// <summary>
        /// Configuration key for setting the timeout in milliseconds for named pipes communication.
        /// Default value is <c>0</c>.
        /// </summary>
        /// <seealso cref="TracerSettings.TracesPipeTimeoutMs"/>
        public const string TracesPipeTimeoutMs = "OTEL_TRACE_PIPE_TIMEOUT_MS";

        /// <summary>
        /// Configuration key for the named pipe that DogStatsD binds to.
        /// Default value is <c>null</c>.
        /// </summary>
        /// <seealso cref="TracerSettings.MetricsPipeName"/>
        public const string MetricsPipeName = "OTEL_DOGSTATSD_PIPE_NAME";

        /// <summary>
        /// Sibling setting for <see cref="AgentPort"/>.
        /// Used to force a specific port binding for the Trace Agent.
        /// Default value is 8126.
        /// </summary>
        /// <seealso cref="TracerSettings.AgentUri"/>
        public const string TraceAgentPortKey = "OTEL_APM_RECEIVER_PORT";

        /// <summary>
        /// Configuration key for the Agent URL where the Tracer can send traces.
        /// Overrides values in <see cref="AgentHost"/> and <see cref="AgentPort"/> if present.
        /// Default value is "http://localhost:8126".
        /// </summary>
        /// <seealso cref="TracerSettings.AgentUri"/>
        public const string AgentUri = "OTEL_TRACE_AGENT_URL";

        /// <summary>
        /// Configuration key for enabling or disabling default Analytics.
        /// </summary>
        /// <seealso cref="TracerSettings.AnalyticsEnabled"/>
        public const string GlobalAnalyticsEnabled = "OTEL_TRACE_ANALYTICS_ENABLED";

        /// <summary>
        /// Configuration key for a list of tags to be applied globally to spans.
        /// </summary>
        /// <seealso cref="TracerSettings.GlobalTags"/>
        public const string GlobalTags = "OTEL_TAGS";

        /// <summary>
        /// Configuration key for a map of header keys to tag names.
        /// Automatically apply header values as tags on traces.
        /// </summary>
        /// <seealso cref="TracerSettings.HeaderTags"/>
        public const string HeaderTags = "OTEL_TRACE_HEADER_TAGS";

        /// <summary>
        /// Configuration key for a map of services to rename.
        /// </summary>
        /// <seealso cref="TracerSettings.ServiceNameMappings"/>
        public const string ServiceNameMappings = "OTEL_TRACE_SERVICE_MAPPING";

        /// <summary>
        /// Configuration key for setting the size in bytes of the trace buffer
        /// </summary>
        public const string BufferSize = "OTEL_TRACE_BUFFER_SIZE";

        /// <summary>
        /// Configuration key for setting the batch interval in milliseconds for the serialization queue
        /// </summary>
        public const string SerializationBatchInterval = "OTEL_TRACE_BATCH_INTERVAL";

        /// <summary>
        /// Configuration key for enabling or disabling the automatic injection
        /// of correlation identifiers into the logging context.
        /// </summary>
        /// <seealso cref="TracerSettings.LogsInjectionEnabled"/>
        public const string LogsInjectionEnabled = "OTEL_LOGS_INJECTION";

        /// <summary>
        /// Configuration key for setting the number of traces allowed
        /// to be submitted per second.
        /// </summary>
        /// <seealso cref="TracerSettings.MaxTracesSubmittedPerSecond"/>
        public const string MaxTracesSubmittedPerSecond = "OTEL_MAX_TRACES_PER_SECOND";

        /// <summary>
        /// Configuration key for enabling or disabling the diagnostic log at startup
        /// </summary>
        /// <seealso cref="TracerSettings.StartupDiagnosticLogEnabled"/>
        public const string StartupDiagnosticLogEnabled = "OTEL_TRACE_STARTUP_LOGS";

        /// <summary>
        /// Configuration key for setting custom sampling rules based on regular expressions.
        /// Semi-colon separated list of sampling rules.
        /// The rule is matched in order of specification. The first match in a list is used.
        ///
        /// Per entry:
        ///   The item "sample_rate" is required in decimal format.
        ///   The item "service" is optional in regular expression format, to match on service name.
        ///   The item "name" is optional in regular expression format, to match on operation name.
        ///
        /// To give a rate of 50% to any traces in a service starting with the text "cart":
        ///   '[{"sample_rate":0.5, "service":"cart.*"}]'
        ///
        /// To give a rate of 20% to any traces which have an operation name of "http.request":
        ///   '[{"sample_rate":0.2, "name":"http.request"}]'
        ///
        /// To give a rate of 100% to any traces within a service named "background" and with an operation name of "sql.query":
        ///   '[{"sample_rate":1.0, "service":"background", "name":"sql.query"}]
        ///
        /// To give a rate of 10% to all traces
        ///   '[{"sample_rate":0.1}]'
        ///
        /// To configure multiple rules, separate by semi-colon and order from most specific to least specific:
        ///   '[{"sample_rate":0.5, "service":"cart.*"}, {"sample_rate":0.2, "name":"http.request"}, {"sample_rate":1.0, "service":"background", "name":"sql.query"}, {"sample_rate":0.1}]'
        ///
        /// If no rules are specified, or none match, default internal sampling logic will be used.
        /// </summary>
        /// <seealso cref="TracerSettings.CustomSamplingRules"/>
        public const string CustomSamplingRules = "OTEL_TRACE_SAMPLING_RULES";

        /// <summary>
        /// Configuration key for setting the global rate for the sampler.
        /// </summary>
        public const string GlobalSamplingRate = "OTEL_TRACE_SAMPLE_RATE";

        /// <summary>
        /// Configuration key for the DogStatsd port where the Tracer can send metrics.
        /// Default value is 8125.
        /// </summary>
        public const string DogStatsdPort = "OTEL_DOGSTATSD_PORT";

        /// <summary>
        /// Configuration key for enabling or disabling internal metrics sent to DogStatsD.
        /// Default value is <c>false</c> (disabled).
        /// </summary>
        public const string TracerMetricsEnabled = "OTEL_TRACE_METRICS_ENABLED";

        /// <summary>
        /// Configuration key for enabling or disabling runtime metrics sent to DogStatsD.
        /// Default value is <c>false</c> (disabled).
        /// </summary>
        public const string RuntimeMetricsEnabled = "OTEL_RUNTIME_METRICS_ENABLED";

        /// <summary>
        /// Configuration key for setting the approximate maximum size,
        /// in bytes, for Tracer log files.
        /// Default value is 10 MB.
        /// </summary>
        public const string MaxLogFileSize = "OTEL_MAX_LOGFILE_SIZE";

        /// <summary>
        /// Configuration key for setting the number of seconds between,
        /// identical log messages, for Tracer log files.
        /// Default value is 60s. Setting to 0 disables rate limiting.
        /// </summary>
        public const string LogRateLimit = "OTEL_TRACE_LOGGING_RATE";

        /// <summary>
        /// Configuration key for setting the path to the .NET Tracer native log file.
        /// This also determines the output folder of the .NET Tracer managed log files.
        /// Overridden by <see cref="LogDirectory"/> if present.
        /// </summary>
        public const string ProfilerLogPath = "OTEL_TRACE_LOG_PATH";

        /// <summary>
        /// Configuration key for setting the directory of the .NET Tracer logs.
        /// Overrides the value in <see cref="ProfilerLogPath"/> if present.
        /// Default value is "%ProgramData%"\OpenTelemetry .NET AutoInstrumentation\logs\" on Windows
        /// or "/var/log/opentelemetry/dotnet/" on Linux.
        /// </summary>
        public const string LogDirectory = "OTEL_TRACE_LOG_DIRECTORY";

        /// <summary>
        /// Configuration key for when a standalone instance of the Trace Agent needs to be started.
        /// </summary>
        public const string TraceAgentPath = "OTEL_TRACE_AGENT_PATH";

        /// <summary>
        /// Configuration key for arguments to pass to the Trace Agent process.
        /// </summary>
        public const string TraceAgentArgs = "OTEL_TRACE_AGENT_ARGS";

        /// <summary>
        /// Configuration key for when a standalone instance of DogStatsD needs to be started.
        /// </summary>
        public const string DogStatsDPath = "OTEL_DOGSTATSD_PATH";

        /// <summary>
        /// Configuration key for arguments to pass to the DogStatsD process.
        /// </summary>
        public const string DogStatsDArgs = "OTEL_DOGSTATSD_ARGS";

        /// <summary>
        /// Configuration key for enabling or disabling the use of System.Diagnostics.DiagnosticSource.
        /// Default value is <c>true</c> (enabled).
        /// </summary>
        public const string DiagnosticSourceEnabled = "OTEL_DIAGNOSTIC_SOURCE_ENABLED";

        /// <summary>
        /// Configuration key for the exporter to be used. The Tracer uses it to encode and
        /// dispatch traces.
        /// Default is <c>"DatadogAgent"</c>.
        /// </summary>
        /// <seealso cref="TracerSettings.Exporter"/>
        public const string Exporter = "OTEL_EXPORTER";

        /// <summary>
        /// Configuration key for the semantic convention to be used.
        /// The Tracer uses it to define operation names, span tags, statuses etc.
        /// Default is <c>"Default"</c>.
        /// <seealso cref="TracerSettings.Convention"/>
        /// </summary>
        public const string Convention = "OTEL_CONVENTION";

        /// <summary>
        /// Configuration key for setting the API key, used by the Agent.
        /// This key is here for troubleshooting purposes.
        /// </summary>
        public const string ApiKey = "OTEL_API_KEY";

        /// <summary>
        /// Configuration key for overriding the transport to use for communicating with the trace agent.
        /// Default value is <c>null</c>.
        /// Override options available: <c>datadog-tcp</c>, <c>datadog-named-pipes</c>
        /// </summary>
        public const string TracesTransport = "OTEL_TRACE_TRANSPORT";

        /// <summary>
        /// Configuration key for the application's server http statuses to set spans as errors by.
        /// </summary>
        /// <seealso cref="TracerSettings.HttpServerErrorStatusCodes"/>
        public const string HttpServerErrorStatusCodes = "OTEL_HTTP_SERVER_ERROR_STATUSES";

        /// <summary>
        /// Configuration key for the application's client http statuses to set spans as errors by.
        /// </summary>
        /// <seealso cref="TracerSettings.HttpClientErrorStatusCodes"/>
        public const string HttpClientErrorStatusCodes = "OTEL_HTTP_CLIENT_ERROR_STATUSES";

        /// <summary>
        /// String format patterns used to match integration-specific configuration keys.
        /// </summary>
        public static class Integrations
        {
            /// <summary>
            /// Configuration key pattern for enabling or disabling an integration.
            /// </summary>
            public const string Enabled = "OTEL_TRACE_{0}_ENABLED";

            /// <summary>
            /// Configuration key pattern for enabling or disabling Analytics in an integration.
            /// </summary>
            public const string AnalyticsEnabled = "OTEL_TRACE_{0}_ANALYTICS_ENABLED";

            /// <summary>
            /// Configuration key pattern for setting Analytics sampling rate in an integration.
            /// </summary>
            public const string AnalyticsSampleRate = "OTEL_TRACE_{0}_ANALYTICS_SAMPLE_RATE";
        }

        /// <summary>
        /// String constants for debug configuration keys.
        /// </summary>
        internal static class Debug
        {
            /// <summary>
            /// Configuration key for forcing the automatic instrumentation to only use the mdToken method lookup mechanism.
            /// </summary>
            public const string ForceMdTokenLookup = "OTEL_TRACE_DEBUG_LOOKUP_MDTOKEN";

            /// <summary>
            /// Configuration key for forcing the automatic instrumentation to only use the fallback method lookup mechanism.
            /// </summary>
            public const string ForceFallbackLookup = "OTEL_TRACE_DEBUG_LOOKUP_FALLBACK";
        }
    }
}
