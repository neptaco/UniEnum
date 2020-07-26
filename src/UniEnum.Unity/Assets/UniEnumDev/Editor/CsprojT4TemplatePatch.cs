using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;

namespace Editor
{
    public class CsprojT4TemplatePatch : AssetPostprocessor
    {
        private static string OnGeneratedCSProject(string path, string content)
        {
            var assemblyName = Path.GetFileNameWithoutExtension(path);
            var asmDefPath = CompilationPipeline.GetAssemblyDefinitionFilePathFromAssemblyName(assemblyName);
            var baseDir = Path.GetDirectoryName(asmDefPath) ?? "Assets/";
            
            var templateFiles = Directory.GetFiles(baseDir, "*.tt", SearchOption.AllDirectories);
            if (templateFiles.Length > 0)
            {
                var childAsmDefDirs = Directory.GetFiles(baseDir, "*.asmdef", SearchOption.AllDirectories)
                    .Select(Path.GetDirectoryName)
                    .Where(v => baseDir != v)
                    .ToList();

                bool IsOtherAsmDefTarget(string templatePath) => childAsmDefDirs
                    .Any(v => templatePath.StartsWith(v, StringComparison.Ordinal));

                var targets = templateFiles
                    .Where(v => !IsOtherAsmDefTarget(v))
                    .ToList();

                if (targets.Count > 0)
                {
                    return AppendTemplateContents(content, targets);
                }
            }

            return content;
        }

        private static string AppendTemplateContents(string content, List<string> templateFiles)
        {
            var doc = XDocument.Parse(content);
            AppendTemplateContents(doc, templateFiles);
            return ToPrettyString(doc);
        }

        private static string ToWinPath(string path)
        {
            return path.Replace('/', '\\');
        }

        private static void AppendTemplateContents(XDocument doc, List<string> templateFiles)
        {
            XNamespace ns = "http://schemas.microsoft.com/developer/msbuild/2003";

            var projectNode = doc.Descendants(ns + "Project").First();
            
            var itemGroup = new XElement(ns + "ItemGroup");
            foreach (var templatePath in templateFiles)
            {
                var genFileName = Path.GetFileNameWithoutExtension(templatePath) + ".cs";
                
                var t4Content = new XElement(ns + "Content");
                t4Content.Add(new XAttribute("Include", ToWinPath(templatePath)));
                t4Content.Add(new XElement(ns + "Generator", "TextTemplatingFileGenerator"));
                t4Content.Add(new XElement(ns + "LastGenOutput", genFileName));
                itemGroup.Add(t4Content);

                var templateDir = Path.GetDirectoryName(templatePath);
                var genPath = ToWinPath(Path.Combine(templateDir, genFileName));

                var compileNode = projectNode.Descendants(ns + "Compile")
                    .FirstOrDefault(n => n.Attribute("Include")?.Value == genPath);
                if (compileNode != null)
                {
                    compileNode.Add(new XElement(ns + "AutoGen", "True"));
                    compileNode.Add(new XElement(ns + "DesignTime", "True"));
                    compileNode.Add(new XElement(ns + "DependentUpon", Path.GetFileName(templatePath)));
                }

            }
            projectNode.Add(itemGroup);
        }

        private static string ToPrettyString(XDocument doc)
        {
            var writer = new StringWriter(new StringBuilder());
            var xmlTextWriter = new XmlTextWriter(writer)
            {
                Formatting = Formatting.Indented
            };
            doc.Save(xmlTextWriter);
            return writer.ToString();
        }
    }
}
