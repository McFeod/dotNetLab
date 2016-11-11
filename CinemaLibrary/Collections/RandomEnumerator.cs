using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CinemaLibrary.Collections
{
    /// <summary>
    /// Класс-Enumerator, обеспечивающий произвольный порядок обхода коллекции при итерации по ней
    /// </summary>
    /// <typeparam name="T">Тип элементов коллекции</typeparam>
    public class RandomEnumerator<T> : IEnumerator<T>
    {
        private readonly List<T> _items;
        private List<int> _unusedIndexes;
        private int _position;
        private static Random _random = new Random();

        public RandomEnumerator(List<T> items)
        {
            _items = items;
            _unusedIndexes = new List<int>(Enumerable.Range(0, items.Count));
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_unusedIndexes.Count == 0) return false;
            var idx = _random.Next(_unusedIndexes.Count);
            _position = _unusedIndexes[idx];
            _unusedIndexes.RemoveAt(idx);
            return true;
        }

        public void Reset()
        {
            _unusedIndexes = new List<int>(Enumerable.Range(0, _items.Count));
        }

        public T Current => _items[_position];

        object IEnumerator.Current => Current;
    }
}