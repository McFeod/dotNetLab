using System.Collections;
using System.Collections.Generic;
using LabOneCinema.Artifacts;

namespace LabOneCinema.Collections
{
    /// <summary>
    /// Коллекция фильмов (или других производных от Artifact) на основе List,
    /// но со своим Enumerator-классом
    /// </summary>
    public class Playlist<T> : ICollection<T> where T: Artifact
    {
        private readonly List<T> _films;

        public Playlist()
        {
            _films = new List<T>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new RandomEnumerator<T>(_films);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            _films.Add(item);
        }

        public void Clear()
        {
            _films.Clear();
        }

        public bool Contains(T item)
        {
            return _films.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _films.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _films.Remove(item);
        }

        public int Count => _films.Count;
        public bool IsReadOnly => false;
    }
}