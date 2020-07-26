using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class PackageExporter
{
    private const string PackageDir = "Assets/UniEnum";
    private const string ExportDir = "Artifacts/UnityPackages";
    private const string ExportFileName = "UniEnum";
    
    [MenuItem("UniEnumDev/Export Package")]
    public static void Export()
    {
        var targetFiles = Directory.EnumerateFiles(PackageDir, "*", SearchOption.AllDirectories)
            .Where(v => IsTargetExtension(Path.GetExtension(v)))
            .ToArray();
        
        var version = GetVersion();
        var exportPath = $"{ExportDir}/{ExportFileName}-{version}.unitypackage";

        if (!Directory.Exists(ExportDir))
            Directory.CreateDirectory(ExportDir);
        
        AssetDatabase.ExportPackage(targetFiles, exportPath);

        if (!Application.isBatchMode)
        {
            Process.Start(ExportDir);
        }

    }

    private class PackageInfo
    {
        public string version = null;
    }

    private static string GetVersion()
    {
        var packageJson = Path.Combine(PackageDir, "package.json");
        var packageInfo = JsonUtility.FromJson<PackageInfo>(File.ReadAllText(packageJson));
        return packageInfo.version;
    }

    private static bool IsTargetExtension(string extension)
    {
        switch (extension)
        {
            case ".cs":
            case ".asmdef":
            case ".md":
            case ".json":
                return true;
        }

        return false;
    }
}
