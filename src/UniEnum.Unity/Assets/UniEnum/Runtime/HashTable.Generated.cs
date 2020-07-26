// <auto-genereted>
// This file generated from UniEnum.
// </auto-generated>
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UniEnumUtils
{
    #region IgnoreCaseStringHashTable

    internal sealed class IgnoreCaseStringHashTable<TValue>
    {
        private readonly Entry[][] _buckets;
        private readonly int _indexFor;

        public delegate String KeySelector(in TValue value);

        public IgnoreCaseStringHashTable(TValue[] values, KeySelector keySelector)
        {
            const float loadFactor = 0.42f;
            var capacity = values.Length;
            var tableSize = HashTableUtility.CalculateCapacity(capacity, loadFactor);
            _buckets = new Entry[tableSize][];
            _indexFor = _buckets.Length - 1;

            foreach (var v in values)
            {
                Add(keySelector(v), v);
            }
        }

        internal void Add(String key, TValue value)
        {
            var hash = StringComparer.OrdinalIgnoreCase.GetHashCode(key);
            var entry = new Entry(key, value);

            var index = hash & _indexFor;
            Entry[] entries = _buckets[index];
            if (entries == null)
            {
                _buckets[index] = new[] { entry };
            }
            else
            {
　　　　　　　　　　　// Duplicates will not be checked.

                var newArray = new Entry[entries.Length + 1];
                Array.Copy(entries, newArray, entries.Length);
                entries = newArray;
                entries[entries.Length - 1] = entry;
                _buckets[index] = entries;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetValue(String key, out TValue value)
        {
            var hash = StringComparer.OrdinalIgnoreCase.GetHashCode(key);
            var index = hash & _indexFor;
            Entry[] entries = _buckets[index];

            if (entries == null)
            {
                value = default;
                return false;
            }

            if (entries[0].Key.Equals(key, StringComparison.OrdinalIgnoreCase))
            {
                value = entries[0].Value;
                return true;
            }

            return TryGetValueSlow(key, entries, out value);
        }

        private bool TryGetValueSlow(String key, Entry[] entries, out TValue value)
        {
            for (int i = 1; i < entries.Length; i++)
            {
                if (entries[i].Key.Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    value = entries[i].Value;
                    return true;
                }
            }

            value = default;
            return false;
        }

        private readonly struct Entry
        {
            public readonly String Key;
            public readonly TValue Value;

            public Entry(String key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }
    }

    #endregion

    #region StringHashTable

    internal sealed class StringHashTable<TValue>
    {
        private readonly Entry[][] _buckets;
        private readonly int _indexFor;

        public delegate String KeySelector(in TValue value);

        public StringHashTable(TValue[] values, KeySelector keySelector)
        {
            const float loadFactor = 0.42f;
            var capacity = values.Length;
            var tableSize = HashTableUtility.CalculateCapacity(capacity, loadFactor);
            _buckets = new Entry[tableSize][];
            _indexFor = _buckets.Length - 1;

            foreach (var v in values)
            {
                Add(keySelector(v), v);
            }
        }

        internal void Add(String key, TValue value)
        {
            var hash = key.GetHashCode();
            var entry = new Entry(key, value);

            var index = hash & _indexFor;
            Entry[] entries = _buckets[index];
            if (entries == null)
            {
                _buckets[index] = new[] { entry };
            }
            else
            {
　　　　　　　　　　　// Duplicates will not be checked.

                var newArray = new Entry[entries.Length + 1];
                Array.Copy(entries, newArray, entries.Length);
                entries = newArray;
                entries[entries.Length - 1] = entry;
                _buckets[index] = entries;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetValue(String key, out TValue value)
        {
            var hash = key.GetHashCode();
            var index = hash & _indexFor;
            Entry[] entries = _buckets[index];

            if (entries == null)
            {
                value = default;
                return false;
            }

            if (entries[0].Key.Equals(key))
            {
                value = entries[0].Value;
                return true;
            }

            return TryGetValueSlow(key, entries, out value);
        }

        private bool TryGetValueSlow(String key, Entry[] entries, out TValue value)
        {
            for (int i = 1; i < entries.Length; i++)
            {
                if (entries[i].Key.Equals(key))
                {
                    value = entries[i].Value;
                    return true;
                }
            }

            value = default;
            return false;
        }

        private readonly struct Entry
        {
            public readonly String Key;
            public readonly TValue Value;

            public Entry(String key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }
    }

    #endregion

    #region Int32HashTable

    internal sealed class Int32HashTable<TValue>
    {
        private readonly Entry[][] _buckets;
        private readonly int _indexFor;

        public delegate Int32 KeySelector(in TValue value);

        public Int32HashTable(TValue[] values, KeySelector keySelector)
        {
            const float loadFactor = 0.42f;
            var capacity = values.Length;
            var tableSize = HashTableUtility.CalculateCapacity(capacity, loadFactor);
            _buckets = new Entry[tableSize][];
            _indexFor = _buckets.Length - 1;

            foreach (var v in values)
            {
                Add(keySelector(v), v);
            }
        }

        internal void Add(Int32 key, TValue value)
        {
            var hash = key.GetHashCode();
            var entry = new Entry(key, value);

            var index = hash & _indexFor;
            Entry[] entries = _buckets[index];
            if (entries == null)
            {
                _buckets[index] = new[] { entry };
            }
            else
            {
　　　　　　　　　　　// Duplicates will not be checked.

                var newArray = new Entry[entries.Length + 1];
                Array.Copy(entries, newArray, entries.Length);
                entries = newArray;
                entries[entries.Length - 1] = entry;
                _buckets[index] = entries;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetValue(Int32 key, out TValue value)
        {
            var hash = key.GetHashCode();
            var index = hash & _indexFor;
            Entry[] entries = _buckets[index];

            if (entries == null)
            {
                value = default;
                return false;
            }

            if (entries[0].Key.Equals(key))
            {
                value = entries[0].Value;
                return true;
            }

            return TryGetValueSlow(key, entries, out value);
        }

        private bool TryGetValueSlow(Int32 key, Entry[] entries, out TValue value)
        {
            for (int i = 1; i < entries.Length; i++)
            {
                if (entries[i].Key.Equals(key))
                {
                    value = entries[i].Value;
                    return true;
                }
            }

            value = default;
            return false;
        }

        private readonly struct Entry
        {
            public readonly Int32 Key;
            public readonly TValue Value;

            public Entry(Int32 key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }
    }

    #endregion

    #region HashTable

    internal sealed class HashTable<TKey, TValue>
    {
        private readonly Entry[][] _buckets;
        private readonly int _indexFor;

        public delegate TKey KeySelector(in TValue value);

        public HashTable(TValue[] values, KeySelector keySelector)
        {
            const float loadFactor = 0.42f;
            var capacity = values.Length;
            var tableSize = HashTableUtility.CalculateCapacity(capacity, loadFactor);
            _buckets = new Entry[tableSize][];
            _indexFor = _buckets.Length - 1;

            foreach (var v in values)
            {
                Add(keySelector(v), v);
            }
        }

        internal void Add(TKey key, TValue value)
        {
            var hash = EqualityComparer<TKey>.Default.GetHashCode(key);
            var entry = new Entry(key, value);

            var index = hash & _indexFor;
            Entry[] entries = _buckets[index];
            if (entries == null)
            {
                _buckets[index] = new[] { entry };
            }
            else
            {
　　　　　　　　　　　// Duplicates will not be checked.

                var newArray = new Entry[entries.Length + 1];
                Array.Copy(entries, newArray, entries.Length);
                entries = newArray;
                entries[entries.Length - 1] = entry;
                _buckets[index] = entries;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetValue(TKey key, out TValue value)
        {
            var hash = EqualityComparer<TKey>.Default.GetHashCode(key);
            var index = hash & _indexFor;
            Entry[] entries = _buckets[index];

            if (entries == null)
            {
                value = default;
                return false;
            }

            if (EqualityComparer<TKey>.Default.Equals(entries[0].Key, key))
            {
                value = entries[0].Value;
                return true;
            }

            return TryGetValueSlow(key, entries, out value);
        }

        private bool TryGetValueSlow(TKey key, Entry[] entries, out TValue value)
        {
            for (int i = 1; i < entries.Length; i++)
            {
                if (EqualityComparer<TKey>.Default.Equals(entries[i].Key, key))
                {
                    value = entries[i].Value;
                    return true;
                }
            }

            value = default;
            return false;
        }

        private readonly struct Entry
        {
            public readonly TKey Key;
            public readonly TValue Value;

            public Entry(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }
    }

    #endregion

    
}

