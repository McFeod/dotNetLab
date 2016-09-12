using System.Collections;
using System.Collections.Generic;
using LabOneCinema.Artifacts;

namespace LabOneCinema.Collections
{
    /// <summary>
    /// Коллекция фильмов на основе List, но со своим Enumerator-классом
    /// </summary>
    public class Playlist : ICollection<Film>
    {
        private readonly List<Film> _films;

        public Playlist()
        {
            _films = new List<Film>();
        }

        public IEnumerator<Film> GetEnumerator()
        {
            return new RandomEnumerator<Film>(_films);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Film item)
        {
            _films.Add(item);
        }

        public void Clear()
        {
            _films.Clear();
        }

        public bool Contains(Film item)
        {
            return _films.Contains(item);
        }

        public void CopyTo(Film[] array, int arrayIndex)
        {
            _films.CopyTo(array, arrayIndex);
        }

        public bool Remove(Film item)
        {
            return _films.Remove(item);
        }

        public int Count => _films.Count;
        public bool IsReadOnly => false;
    }
}