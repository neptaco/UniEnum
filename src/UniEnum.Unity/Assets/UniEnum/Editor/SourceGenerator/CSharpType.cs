using System;
using System.Collections.Generic;
using System.Text;

namespace UniEnumUtils.SourceGenerator
{
    internal enum CSharpTypeId
    {
        Class,
        Enum,
        Struct,
    }

    internal enum AccessModifier
    {
        Public,
        Protected,
        Internal,
        Private,
    }
    
    [Flags]
    internal enum Modifier
    {
        None = 0,
        Const = 1 << 1,
        Static = 1 << 2,
        Readonly = 1 << 3,
        
        StaticReadonly = Static | Readonly,
    }

    internal abstract class CSharpType
    {
        public readonly List<string> UsingNamespaces = new List<string>();

        public abstract CSharpTypeId TypeId { get; }

        public string Namespace { get; set; }

        public string Comment { get; set; }

        public AccessModifier AccessModifier { get; set; } = AccessModifier.Public;

        public Modifier Modifier { get; set; }

        public string TypeName { get; set; }

        public readonly List<Variable> Fields = new List<Variable>();
        
        public CSharpType(string nameSpace, string typeName)
        {
            Namespace = nameSpace;
            TypeName = typeName;
        }

        public string GetClassDeclareString()
        {
            var sb = new StringBuilder(128);
            sb.AppendAccessModifier(AccessModifier);
            sb.AppendVariableDeclareModifier(Modifier);
            sb.Append(TypeId.ToString().ToLower());
            sb.Append(' ');
            sb.Append(TypeName);
            return sb.ToString();
        }
    }

    internal class CSharpEnum : CSharpType
    {
        public override CSharpTypeId TypeId => CSharpTypeId.Enum;
        
        public bool IsFlags { get; set; }

        public CSharpEnum(string nameSpace, string typeName) : base(nameSpace, typeName)
        {
        }
    }

    internal class CSharpClass : CSharpType
    {
        public override CSharpTypeId TypeId => CSharpTypeId.Class;

        public CSharpClass(string nameSpace, string typeName) : base(nameSpace, typeName)
        {
        }
    }

    internal class Variable
    {
        private string _name;

        public AccessModifier AccessLevel { get; set; } = AccessModifier.Public;
        
        public Modifier Modifier { get; set; }

        public string TypeName { get; set; }

        public string Name
        {
            get => _name;
            set => _name = value.SanitizeForIdentifier();
        }
        
        public string Value { get; set; }
        
        public string Comment { get; set; }

        public Variable(string type, string name, string value, Modifier modifier = Modifier.None, string comment = null)
        {
            TypeName = type;
            Name = name;
            Value = value;
            Modifier = modifier;
            Comment = comment;
        }

        public string ToFieldDeclareString()
        {
            var sb = new StringBuilder(128);

            sb.AppendAccessModifier(AccessLevel);
            sb.AppendVariableDeclareModifier(Modifier);

            sb.Append(TypeName);
            sb.Append(' ');
            sb.Append(Name);
            sb.Append(" = ");
            sb.Append(Value);
            sb.Append(";");

            return sb.ToString();
        }

        public string ToEnumDeclareString()
        {
            var sb = new StringBuilder(128);

            sb.Append(Name);
            
            if (!string.IsNullOrEmpty(Value))
            {
                sb.Append(" = ");
                sb.Append(Value);
            }

            sb.Append(',');

            return sb.ToString();
        }
    }

    internal class MethodInfo
    {
        public string Name;
        
        
    }
    
}
