namespace OpenTelemetry.Instrumentation.Logging
{
    internal interface ILogRateLimiter
    {
        /// <summary>
        /// Check whether a log message for the given location should be written or skipped
        /// </summary>
        /// <param name="filePath">The file path of the source code file writing the log</param>
        /// <param name="lineNumber">The line number of the source code file writing the log</param>
        /// <param name="skipCount">If the log should be written, the number of similar log messages that were previously skipped</param>
        /// <returns><c>true</c> if the log should be written, otherwise <c>false</c></returns>
        bool ShouldLog(string filePath, int lineNumber, out uint skipCount);
    }
}
