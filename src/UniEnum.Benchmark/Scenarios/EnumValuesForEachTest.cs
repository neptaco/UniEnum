using System;
using BenchmarkDotNet.Attributes;
using FastEnumUtility;
using UniEnumUtils;
using UniEnumTests;

namespace UniEnumBenchmark
{
    [Config(typeof(Program.BenchmarkConfig))]
    public class EnumValuesForEachTest
    {
        [GlobalSetup]
        public void Setup()
        {
            _ = UniEnum.GetValues<IntEnum1>();
            _ = FastEnum.GetValues<IntEnum1>();
            _ = Enum.GetValues(typeof(IntEnum1));
        }

        [Benchmark(Baseline = true)]
        public int UniEnum_Values()
        {
            int sum = 0;
            foreach (var v in UniEnum.GetValues<IntEnum1>())
            {
                sum += (int) v;
            }

            return sum;
        }

        [Benchmark]
        public int FastEnum_Values()
        {
            int sum = 0;
            foreach (var v in FastEnum.GetValues<IntEnum1>())
            {
                sum += (int) v;
            }

            return sum;
        }

        [Benchmark]
        public int Enum_Values()
        {
            int sum = 0;
            foreach (var v in Enum.GetValues(typeof(IntEnum1)))
            {
                sum += (int) v;
            }

            return sum;
        }

    }
}
