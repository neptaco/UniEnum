using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using FastEnumUtility;
using UniEnumUtils;
using UniEnumTests;

namespace UniEnumBenchmark
{
    [Config(typeof(Program.BenchmarkConfig))]
    public class EnumValuesTest
    {
        [GlobalSetup]
        public void Setup()
        {
            _ = UniEnum.GetValues<IntEnum1>();
            _ = FastEnum.GetValues<IntEnum1>();
            _ = Enum.GetValues(typeof(IntEnum1));
        }

        [Benchmark(Baseline = true)]
        public ReadOnlyArray<IntEnum1> UniEnum_Values()
        {
            return UniEnum.GetValues<IntEnum1>();
        }

        [Benchmark]
        public IReadOnlyList<IntEnum1> FastEnum_Values()
        {
            return FastEnum.GetValues<IntEnum1>();
        }

        [Benchmark]
        public IntEnum1[] Enum_Values()
        {
            return (IntEnum1[]) Enum.GetValues(typeof(DayOfWeek));
        }

    }
}
