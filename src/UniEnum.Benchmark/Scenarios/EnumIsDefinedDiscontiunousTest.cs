using System;
using BenchmarkDotNet.Attributes;
using FastEnumUtility;
using UniEnumUtils;
using UniEnumTests;

namespace UniEnumBenchmark
{
    [Config(typeof(Program.BenchmarkConfig))]
    public class EnumIsDefinedDiscontinuousTest
    {
        [GlobalSetup]
        public void Setup()
        {
            UniEnum.IsDefined<IntEnum2>(1000);
            FastEnum.IsDefined<IntEnum2>(1000);
        }

        [Benchmark(Baseline = true)]
        public bool UniEnum_Discontinuous_IsDefined()
        {
            return UniEnum.IsDefined<IntEnum2>(1000);
        }

        [Benchmark]
        public bool FastEnum_Discontinuous_IsDefined()
        {
            return FastEnum.IsDefined<IntEnum2>(1000);
        }
    }
}
