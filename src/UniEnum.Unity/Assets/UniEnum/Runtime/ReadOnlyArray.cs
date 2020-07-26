using System;
using System.Collections;
using System.Collections.Generic;

namespace UniEnumUtils
{
    public sealed class ReadOnlyArray<T> : IReadOnlyList<T>
    {
        private readonly T[] _source;

        public ReadOnlyArray(T[] array)
        {
            _source = array;
            Count = array.Length;
        }
        
        public Enumerator GetEnumerator()
        {
            return new Enumerator(_source);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Enumerator(_source);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public int Count { get; }

        public T this[int index] => _source[index];

        public struct Enumerator : IEnumerator<T>
        {
            private readonly T[] _source;
            private int _index;
            
            public Enumerator(T[] array)
            {
                _source = array;
                _index = -1;
            }

            public void Dispose()
            {
            }
            
            public T Current => _source[_index];

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                _index++;
                return (uint)_index < (uint)_source.Length;
            }

            public void Reset()
            {
                _index = -1;
            }

        }
    }
}
