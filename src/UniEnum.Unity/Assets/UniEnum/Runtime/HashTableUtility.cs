using System;
using System.Collections.Generic;

namespace UniEnumUtils
{
    internal static class HashTableUtility
    { 
        internal static int CalculateCapacity(int collectionSize, float loadFactor)
        {
            var initialCapacity = (int)(collectionSize / loadFactor);
            var capacity = 1;
            while (capacity < initialCapacity)
            {
                capacity <<= 1;
            }

            if (capacity < 8)
            {
                return 8;
            }

            return capacity;
        }
    }
}
