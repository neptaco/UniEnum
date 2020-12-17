# UniEnum

Provides enumeration values utilities for Unity.

- Fast utilitiy methods for enum. (GetValue, GetNames, IsDefined, TryParase etc..)

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
  [Host]   : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT  [AttachedDebugger]
  ShortRun : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```

### GetValues

|          Method |        Mean |       Error |    StdDev |      Median |     Ratio |  RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------:|------------:|----------:|------------:|----------:|---------:|-------:|------:|------:|----------:|
|  UniEnum_Values |   0.0931 ns |   0.8366 ns | 0.0459 ns |   0.1120 ns |      1.00 |     0.00 |      - |     - |     - |         - |
| FastEnum_Values |   0.1494 ns |   1.3796 ns | 0.0756 ns |   0.1634 ns |      2.44 |     2.54 |      - |     - |     - |         - |
|     Enum_Values | 767.8288 ns | 109.8056 ns | 6.0188 ns | 765.2773 ns | 10,559.26 | 7,092.53 | 0.0706 |     - |     - |     224 B |

### TryParse

|                              Method |        Mean |        Error |     StdDev |  Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |------------:|-------------:|-----------:|-------:|--------:|------:|------:|------:|----------:|
|    UniEnum_TryParse_CaseSensitive_1 |    16.72 ns |    11.874 ns |   0.651 ns |   1.00 |    0.00 |     - |     - |     - |         - |
|   FastEnum_TryParse_CaseSensitive_1 |    21.33 ns |    11.664 ns |   0.639 ns |   1.28 |    0.09 |     - |     - |     - |         - |
|  UniEnum_TryParse_CaseSensitive_500 |    17.02 ns |     4.245 ns |   0.233 ns |   1.02 |    0.05 |     - |     - |     - |         - |
| FastEnum_TryParse_CaseSensitive_500 |    21.79 ns |    15.696 ns |   0.860 ns |   1.31 |    0.08 |     - |     - |     - |         - |
|       UniEnum_TryParse_IgnoreCase_1 |    24.22 ns |     7.067 ns |   0.387 ns |   1.45 |    0.03 |     - |     - |     - |         - |
|      FastEnum_TryParse_IgnoreCase_1 |    17.61 ns |     8.040 ns |   0.441 ns |   1.05 |    0.06 |     - |     - |     - |         - |
|    FastEnum_TryParse_IgnoreCase_500 | 4,821.54 ns | 2,057.946 ns | 112.803 ns | 288.58 |    9.61 |     - |     - |     - |         - |


|                           Method |     Mean |    Error |    StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------------- |---------:|---------:|----------:|------:|--------:|------:|------:|------:|----------:|
|  UniEnum_Discontinuous_IsDefined | 2.246 ns | 1.510 ns | 0.0828 ns |  1.00 |    0.00 |     - |     - |     - |         - |
| FastEnum_Discontinuous_IsDefined | 4.375 ns | 1.105 ns | 0.0606 ns |  1.95 |    0.05 |     - |     - |     - |         - |


### License

This library is under the MIT License.