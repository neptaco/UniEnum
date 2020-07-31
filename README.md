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



### License

This library is under the MIT License.