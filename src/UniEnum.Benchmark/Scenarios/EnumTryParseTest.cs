using BenchmarkDotNet.Attributes;
using FastEnumUtility;
using UniEnumUtils;
using UniEnumTests;

namespace UniEnumBenchmark
{
    [Config(typeof(Program.BenchmarkConfig))]
    public class EnumTryParseTest
    {
        [GlobalSetup]
        public void Setup()
        {
            UniEnum.TryParse<IntEnum1>("Type1", out _);
            FastEnum.TryParse<IntEnum1>("Type1", out _);
        }

        [Benchmark(Baseline = true)]
        public bool UniEnum_TryParse_CaseSensitive_1()
        {
            return UniEnum.TryParse<IntEnum1>("Type1", out _);
        }

        [Benchmark]
        public bool FastEnum_TryParse_CaseSensitive_1()
        {
            return FastEnum.TryParse<IntEnum1>("Type1", out _);
        }
        
        [Benchmark]
        public bool UniEnum_TryParse_CaseSensitive_500()
        {
            return UniEnum.TryParse<IntEnum1>("Type500", out _);
        }

        [Benchmark]
        public bool FastEnum_TryParse_CaseSensitive_500()
        {
            return FastEnum.TryParse<IntEnum1>("Type500", out _);
        }
        
        [Benchmark]
        public bool UniEnum_TryParse_IgnoreCase_1()
        {
            return UniEnum.TryParse<IntEnum1>("Type1", true, out _);
        }

        [Benchmark]
        public bool FastEnum_TryParse_IgnoreCase_1()
        {
            return FastEnum.TryParse<IntEnum1>("Type1", true, out _);
        }
        
        [Benchmark]
        public bool UniEnum_TryParse_IgnoreCase_500()
        {
            return UniEnum.TryParse<IntEnum1>("Type500", true, out _);
        }

        [Benchmark]
        public bool FastEnum_TryParse_IgnoreCase_500()
        {
            return FastEnum.TryParse<IntEnum1>("Type500", true, out _);
        }
        
    }
}
