using BenchmarkDotNet.Attributes;
using FastEnumUtility;
using UniEnumUtils;
using UniEnumTests;

namespace UniEnumBenchmark
{
    [Config(typeof(Program.BenchmarkConfig))]
    public class EnumIsDefinedTest
    {
        [GlobalSetup]
        public void Setup()
        {
            UniEnum.IsDefined<IntEnum1>(1000);
            FastEnum.IsDefined<IntEnum1>(1000);
        }
        
        [Benchmark(Baseline = true)]
        public bool UniEnum_Continuous_IsDefined()
        {
            return UniEnum.IsDefined<IntEnum1>(1);
        }

        [Benchmark]
        public bool FastEnum_Continuous_IsDefined()
        {
            return FastEnum.IsDefined<IntEnum1>(1);
        }
    }
}
