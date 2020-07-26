using BenchmarkDotNet.Attributes;
using FastEnumUtility;
using UniEnumUtils;
using UniEnumTests;

namespace UniEnumBenchmark
{
    [Config(typeof(Program.BenchmarkConfig))]
    public class EnumIsDefinedShortTest
    {
        [GlobalSetup]
        public void Setup()
        {
            UniEnum.IsDefined<ShortEnum1>(1000);
            FastEnum.IsDefined<ShortEnum1>(1000);
        }
        
        [Benchmark(Baseline = true)]
        public bool UniEnum_Short_IsDefined()
        {
            return UniEnum.IsDefined<ShortEnum1>((short)1000);
        }

        [Benchmark]
        public bool FastEnum_Short_IsDefined()
        {
            return FastEnum.IsDefined<ShortEnum1>((short)1000);
        }

    }
}
