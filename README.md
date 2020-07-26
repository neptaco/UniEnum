# UniEnum

Provides enumeration values utilities for Unity.

- Fast utilitiy methods for enum. (GetValue, GetNames, IsDefined, TryParase etc..)
- Automate the creation of Unity's constant values as enumerations. (Scene, Tag, Layer, SortingLayer)

## Install

1. Install from UnityPackage from Release Page
2. Package Manager

### UnityPackage

Download .unitypackage from [Release Page](https://github.com/neptaco/UniEnum/releases)

### Package Manager

```manifest.json
{
    "dependencies": {
        "jp.xtals.unienum": "https://github.com/neptaco/UniEnum.git?path=src/UniEnum.Unity/Assets/UniEnum"
    }
}
```


## Enum Utility Methods

|.NET|UniEnum|
|----|-------|
|Enum.GetNames(typeof(EnumType))|UniEnum.GetNames\<EnumTypes>()|
|Enum.GetValues(typeof(EnumType))|UniEnum.GetValues\<EnumTypes>()|
|Enum.IsDefined(typeof(EnumType), v)|UniEnum.IsDefined\<EnumTypes>(v) [^1]|
|Enum.TryParse(typeof(EnumType))|UniEnum.TryParse\<EnumTypes>(v)|


[^1]: `UniEnum.IsDefined` is case sensitive.

## Generate Unity constant values

Setup generate targets from `ProjectSettings -> UniEnum`.

|Target|Generate classes|
|----|-------|
|Scene|SceneId<br/>SceneName<br/>ScenePath|
|Layer|LayerId<br/>LayerMaskValue|
|SortingLayer|SortingLyaerId<br/>SortingLayerName|
|Tag|TagName|


### License

This library is under the MIT License.