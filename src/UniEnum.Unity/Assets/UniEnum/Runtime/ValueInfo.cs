using System;

namespace UniEnumUtils
{
    internal readonly struct ValueInfo<T> where T : Enum
    {
        public readonly T EnumValue;
        public readonly string Name;

        public ValueInfo(T enumValue, string name)
        {
            EnumValue = enumValue;
            Name = name;
        }
    }
}
