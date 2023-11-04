using System;
using System.Runtime.CompilerServices;

namespace UniEnumUtils
{
    public static partial class UniEnum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetName<T>(T v) where T : unmanaged, Enum
            => UnderlyingTypeInfo<T>.Operation.GetName(v); 
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<string> GetNames<T>() where T : Enum 
            => NameCache<T>.ReadOnlyNames;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<T> GetValues<T>() where T : unmanaged, Enum 
            => ValueCache<T>.ReadOnlyValues;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetCount<T>() where T : unmanaged, Enum
            => ValueCache<T>.ReadOnlyValues.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetMinValue<T>() where T : unmanaged, Enum
            => UnderlyingTypeInfo<T>.Operation.GetMinValue();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetMaxValue<T>() where T : unmanaged, Enum
            => UnderlyingTypeInfo<T>.Operation.GetMaxValue();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsDefined<T>(T value) where T : unmanaged, Enum
            => UnderlyingTypeInfo<T>.Operation.IsDefined(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryParse<T>(string text, out T result) where T : unmanaged, Enum
            => TryParseInternal(text, false, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryParse<T>(string text, bool ignoreCase, out T result) where T : unmanaged, Enum
            => TryParseInternal(text, ignoreCase, out result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryParseInternal<T>(string text, bool ignoreCase, out T result) where T : unmanaged, Enum
        {
            if (string.IsNullOrEmpty(text))
            {
                result = default;
                return false;
            }

            if (IsNumeric(text[0]))
                return UnderlyingTypeInfo<T>.Operation.TryParse(text, out result);

            return TryParseName(text, ignoreCase, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsNumeric(char c)
            => char.IsDigit(c) || c == '-' || c == '+';


        private static bool TryParseName<T>(string text, bool ignoreCase, out T result) where T : unmanaged, Enum
        {
            if (ignoreCase)
            {
                if (IgnoreCaseNameTable<T>.Table.TryGetValue(text, out var info))
                {
                    result = info.EnumValue;
                    return true;
                }
            }
            else
            {
                if (NameTable<T>.Table.TryGetValue(text, out var info))
                {
                    result = info.EnumValue;
                    return true;
                }
            }

            result = default;
            return false;
        }
    }
}
