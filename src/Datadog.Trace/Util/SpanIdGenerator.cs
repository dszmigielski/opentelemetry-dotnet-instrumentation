using System;

namespace OpenTelemetry.Instrumentation.Util
{
    internal class SpanIdGenerator
    {
#if NETFRAMEWORK
        private static readonly Random GlobalSeedGenerator = new Random();
#endif

        [ThreadStatic]
        private static SpanIdGenerator _threadInstance;

        private readonly Random _random;

        public SpanIdGenerator()
        {
            _random = new Random();
        }

        public SpanIdGenerator(int seed)
        {
            _random = new Random(seed);
        }

        public static SpanIdGenerator ThreadInstance
        {
            get
            {
                SpanIdGenerator idGenerator = _threadInstance;

                if (idGenerator == null)
                {
#if NETFRAMEWORK
                    // On .NET Framework, the clock is used to seed the new random instances.
                    // Resolution is too low, so if many threads are created at the same time,
                    // some could end up using the same seed.
                    // Instead, use a shared random instance to generate the seed.
                    // The same approach was used for System.Random on .NET Core:
                    // https://docs.microsoft.com/en-us/dotnet/api/system.random.-ctor?view=netcore-3.1
                    int seed;

                    lock (GlobalSeedGenerator)
                    {
                        seed = GlobalSeedGenerator.Next();
                    }

                    idGenerator = new SpanIdGenerator(seed);
#else
                    idGenerator = new SpanIdGenerator();
#endif

                    _threadInstance = idGenerator;
                }

                return idGenerator;
            }
        }

        public ulong CreateNew()
        {
            long high = _random.Next(int.MinValue, int.MaxValue);
            long low = _random.Next(int.MinValue, int.MaxValue);

            // Concatenate both values, and truncate the 32 top bits from low
            var value = high << 32 | (low & 0xFFFFFFFF);

            return (ulong)value & 0x7FFFFFFFFFFFFFFF;
        }
    }
}
