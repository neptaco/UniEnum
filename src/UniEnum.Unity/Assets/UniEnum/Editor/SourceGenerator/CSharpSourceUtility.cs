using System;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;

namespace UniEnumUtils.SourceGenerator
{
    internal static class CSharpSourceUtility
    {
        private static readonly char[] IdentifierInvalidChars =
        {
            ' ', '!', '"', '#', '$',
            '%', '^', '\'', '(', ')',
            '-', '=', '^', '~', '\\',
            '[', '{', '&', '@', '`',
            ']', '}', ':', '*', ';',
            '+', '/', '?', '.', '>',
            ',', '<',
        };
        
        public static string SanitizeForIdentifier(this string identifier)
        {
            var sb = new StringBuilder(identifier.Length + 1);

            foreach (var c in identifier)
            {
                if (FindIndex(IdentifierInvalidChars, c) >= 0)
                    continue;

                sb.Append(c);
            }

            if (char.IsDigit(sb[0]))
            {
                sb.Insert(0, '_');
            }

            return sb.ToString();
        }

        private static int FindIndex(char[] array, char v)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == v)
                    return i;
            }

            return -1;
        }
        
        public static string ToQuoted(this string v)
        {
            return $"\"{v}\"";
        }        

        public static void AppendAccessModifier(this StringBuilder sb, AccessModifier accessLevel)
        {
            sb.Append(accessLevel.ToString().ToLower());
            sb.Append(' ');            
        }

        public static void AppendVariableDeclareModifier(this StringBuilder sb, Modifier keyword)
        {
            if (keyword.HasFlag(Modifier.Const))
            {
                sb.Append("const ");
            }
            else
            {
                if (keyword.HasFlag(Modifier.Static))
                    sb.Append("static ");

                if (keyword.HasFlag(Modifier.Readonly))
                    sb.Append("readonly ");
            }
        }
    }
    
    internal class AssetEditing : IDisposable
    {
        public static AssetEditing Scope() => new AssetEditing();
            
        private AssetEditing()
        {
            AssetDatabase.StartAssetEditing();
        }
            
        public void Dispose()
        {
            AssetDatabase.StopAssetEditing();
        }
    }
    
    internal class IndentState
    {
        private int _indent = 0;

        private string _indentStr = string.Empty;

        public int Indent
        {
            set
            {
                var delta = value - _indent;
                _indent = value;
                if (_indent < 0)
                {
                    _indent = 0;
                    return;
                }
                
                if (delta > 0)
                {
                    for (int i = 0; i < delta; i++)
                        _indentStr += "    ";
                }
                else if (delta < 0)
                {
                    _indentStr = _indentStr.Substring(0, _indent * 4);
                }
            }
            get => _indent;
        }

        public override string ToString() => _indentStr;

        public IndentScope Scope => new IndentScope(this);

        public readonly struct IndentScope : IDisposable
        {
            private readonly IndentState _indent;

            public IndentScope(IndentState indent)
            {
                _indent = indent;
                _indent.Indent += 1;
            }

            public void Dispose()
            {
                _indent.Indent -= 1;
            }
        }
    }
    
    
}
