using System.Threading;

namespace OpenTelemetry.Instrumentation.RuntimeMetrics
{
    internal class Timing
    {
        private double _cumulatedMilliseconds;

        public void Time(double elapsedMilliseconds)
        {
            double oldValue;

            do
            {
                oldValue = _cumulatedMilliseconds;
            }
            while (Interlocked.CompareExchange(ref _cumulatedMilliseconds, oldValue + elapsedMilliseconds, oldValue) != oldValue);
        }

        public double Clear()
        {
            return Interlocked.Exchange(ref _cumulatedMilliseconds, 0);
        }
    }
}
