# UniEnum

[![openupm](https://img.shields.io/npm/v/com.xtaltools.unienum?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.xtaltools.unienum/)
![Nuget](https://img.shields.io/nuget/v/UniEnum)
![Test](https://github.com/neptaco/UniEnum/workflows/Test/badge.svg)

Provides enumeration values utilities for Unity.

- Fast utilitiy methods for enum. (GetValue, GetNames, IsDefined, TryParase etc..)

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
## Table of Contents

- [Install](#install)
- [Enum Utility Methods](#enum-utility-methods)
- [Benchmark](#benchmark)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

## Install

1. Install from UnityPackage from Release Page
2. Package Manager

### UnityPackage

Download .unitypackage from [Release Page](https://github.com/neptaco/UniEnum/releases)

### Package Manager

```manifest.json
{
    "dependencies": {
        "com.xtaltools.unienum": "https://github.com/neptaco/UniEnum.git?path=src/UniEnum.Unity/Assets/UniEnum"
    }
}
```


## Enum Utility Methods

|.NET|UniEnum|
|----|-------|
|Enum.GetNames(typeof(EnumType))|UniEnum.GetNames\<EnumType>()|
|Enum.GetValues(typeof(EnumType))|UniEnum.GetValues\<EnumType>()|
|Enum.IsDefined(typeof(EnumType), v)|UniEnum.IsDefined\<EnumType>(v) [^1]|
|Enum.TryParse(typeof(EnumType))|UniEnum.TryParse\<EnumType>(v)|


*Note*

[^1]: `UniEnum.IsDefined` is case sensitive.

## Benchmark

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.630 (2004/?/20H1)
Intel Core i5-8259U CPU 2.30GHz (Coffee Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]   : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  ShortRun : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
```

### GetValues

|          Method |        Mean |       Error |    StdDev |      Median |     Ratio |  RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------:|------------:|----------:|------------:|----------:|---------:|-------:|------:|------:|----------:|
|  UniEnum_Values |   0.0931 ns |   0.8366 ns | 0.0459 ns |   0.1120 ns |      1.00 |     0.00 |      - |     - |     - |         - |
| FastEnum_Values |   0.1494 ns |   1.3796 ns | 0.0756 ns |   0.1634 ns |      2.44 |     2.54 |      - |     - |     - |         - |
|     Enum_Values | 767.8288 ns | 109.8056 ns | 6.0188 ns | 765.2773 ns | 10,559.26 | 7,092.53 | 0.0706 |     - |     - |     224 B |

### TryParse

|                              Method |        Mean |      Error |    StdDev |  Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |------------:|-----------:|----------:|-------:|--------:|------:|------:|------:|----------:|
|    UniEnum_TryParse_CaseSensitive_1 |    16.01 ns |  11.717 ns |  0.642 ns |   1.00 |    0.00 |     - |     - |     - |         - |
|   FastEnum_TryParse_CaseSensitive_1 |    20.38 ns |   4.270 ns |  0.234 ns |   1.27 |    0.05 |     - |     - |     - |         - |
|  UniEnum_TryParse_CaseSensitive_500 |    16.21 ns |   4.119 ns |  0.226 ns |   1.01 |    0.05 |     - |     - |     - |         - |
| FastEnum_TryParse_CaseSensitive_500 |    20.65 ns |   2.056 ns |  0.113 ns |   1.29 |    0.05 |     - |     - |     - |         - |
|       UniEnum_TryParse_IgnoreCase_1 |    21.31 ns |  12.460 ns |  0.683 ns |   1.33 |    0.02 |     - |     - |     - |         - |
|      FastEnum_TryParse_IgnoreCase_1 |    16.40 ns |   5.825 ns |  0.319 ns |   1.03 |    0.06 |     - |     - |     - |         - |
|     UniEnum_TryParse_IgnoreCase_500 |    23.99 ns |  10.884 ns |  0.597 ns |   1.50 |    0.02 |     - |     - |     - |         - |
|    FastEnum_TryParse_IgnoreCase_500 | 4,363.10 ns | 972.177 ns | 53.288 ns | 272.76 |   11.38 |     - |     - |     - |         - |

### IsDefined

|                           Method |      Mean |     Error |    StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------------- |----------:|----------:|----------:|------:|--------:|------:|------:|------:|----------:|
|     UniEnum_Continuous_IsDefined | 0.8545 ns | 0.1330 ns | 0.0073 ns |  1.00 |    0.00 |     - |     - |     - |         - |
|    FastEnum_Continuous_IsDefined | 3.5935 ns | 0.7328 ns | 0.0402 ns |  4.21 |    0.08 |     - |     - |     - |         - |

|                           Method |     Mean |     Error |    StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------------- |---------:|----------:|----------:|------:|--------:|------:|------:|------:|----------:|
|  UniEnum_Discontinuous_IsDefined | 2.001 ns | 0.1944 ns | 0.0107 ns |  1.00 |    0.00 |     - |     - |     - |         - |
| FastEnum_Discontinuous_IsDefined | 4.030 ns | 0.6492 ns | 0.0356 ns |  2.01 |    0.02 |     - |     - |     - |         - |

|                   Method |      Mean |     Error |    StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----------:|----------:|----------:|------:|--------:|------:|------:|------:|----------:|
|  UniEnum_Short_IsDefined | 0.9304 ns | 0.4986 ns | 0.0273 ns |  1.00 |    0.00 |     - |     - |     - |         - |
| FastEnum_Short_IsDefined | 3.2503 ns | 0.5247 ns | 0.0288 ns |  3.50 |    0.12 |     - |     - |     - |         - |

### License

This library is under the MIT License.
