using System.Runtime.CompilerServices;

namespace UniEnumUtils
{
    internal static class Unsafe
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static unsafe TTo As<TFrom, TTo>(TFrom value)
            where TFrom : unmanaged 
            where TTo : unmanaged
            => *(TTo*) &value;
    }
}
