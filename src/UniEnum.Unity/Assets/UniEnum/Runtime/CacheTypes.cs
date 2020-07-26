using System;

namespace UniEnumUtils
{

    static class NameCache<T> where T : Enum
    {
        public static readonly string[] Names;
        public static readonly ReadOnlyArray<string> ReadOnlyNames;

        static NameCache()
        {
            Names = Enum.GetNames(typeof(T));
            ReadOnlyNames = new ReadOnlyArray<string>(Names);
        }
    }

    static class NameTable<T> where T : unmanaged, Enum
    {
        public static readonly StringHashTable<ValueInfo<T>> Table;

        static NameTable()
        {
            Table = new StringHashTable<ValueInfo<T>>(
                ValueInfoCache<T>.ValueInfos,
                (in ValueInfo<T> info) => info.Name);
        }
    }

    static class IgnoreCaseNameTable<T> where T : unmanaged, Enum
    {
        public static readonly IgnoreCaseStringHashTable<ValueInfo<T>> Table;

        static IgnoreCaseNameTable()
        {
            Table = new IgnoreCaseStringHashTable<ValueInfo<T>>(
                ValueInfoCache<T>.ValueInfos,
                (in ValueInfo<T> info) => info.Name);
        }
    }

    static class ValueCache<T> where T : struct, Enum
    {
        public static readonly T[] Values;
        public static readonly ReadOnlyArray<T> ReadOnlyValues;

        static ValueCache()
        {
            Values = (T[]) Enum.GetValues(typeof(T));
            ReadOnlyValues = new ReadOnlyArray<T>(Values);
        }
    }

    static class UnderlyingTypeInfo<T> where T : unmanaged, Enum
    {
        public static readonly Type UnderlyingType;
        public static readonly TypeCode UnderlyingTypeCode;
        public static readonly IUnderlyingOperation<T> Operation;
        
        static UnderlyingTypeInfo()
        {
            UnderlyingType = Enum.GetUnderlyingType(typeof(T));
            UnderlyingTypeCode = Type.GetTypeCode(UnderlyingType);
            Operation = GetOperation();
        }

        private static IUnderlyingOperation<T> GetOperation()
        {
            switch (Type.GetTypeCode(UnderlyingType))
            {
                case TypeCode.SByte: return SByteEnum<T>.Operation;
                case TypeCode.Byte: return ByteEnum<T>.Operation;
                case TypeCode.Int16: return Int16Enum<T>.Operation;
                case TypeCode.UInt16: return UInt16Enum<T>.Operation;
                case TypeCode.Int32: return Int32Enum<T>.Operation;
                case TypeCode.UInt32: return UInt32Enum<T>.Operation;
                case TypeCode.Int64: return Int64Enum<T>.Operation;
                case TypeCode.UInt64: return UInt64Enum<T>.Operation;
            }

            throw new NotImplementedException(UnderlyingType.Name);
        }
    }

    internal static class ValueInfoCache<T> where T : unmanaged, Enum
    {
        public static readonly ValueInfo<T>[] ValueInfos;

        static ValueInfoCache()
        {
            var values = ValueCache<T>.Values;
            var names = NameCache<T>.Names;
            ValueInfos = new ValueInfo<T>[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                ValueInfos[i] = new ValueInfo<T>(values[i], names[i]);
            }
        }
    }

}
