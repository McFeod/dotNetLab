using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LabOneCinema.Artifacts;
using LabOneCinema.Delegates;

namespace LabOneCinema.Collections
{
    /// <summary>
    /// Коллекция фильмов (или других производных от Artifact) на основе List,
    /// но со своим Enumerator-классом
    /// </summary>
    public class Playlist<T> : ICollection<T> where T: Artifact
    {
        private readonly List<T> _films;
        private readonly bool _isRandom;

        /// <summary>
        /// Конструктор, позволяющий создавать плейлисты с перемешиванием и без
        /// </summary>
        /// <param name="isRandom">Нужен ли случайный порядок элементов</param>
        public Playlist(bool isRandom=true)
        {
            _films = new List<T>();
            _isRandom = isRandom;

        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_isRandom)
                return new RandomEnumerator<T>(_films);
            return _films.GetEnumerator();
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

        /// <summary>
        /// Метод сортировки коллекции.
        /// </summary>
        /// <param name="rule">Делегат, определяющий операцию сравнения элементов</param>
        public void Sort(ComparsionRule<T> rule)
        {
            _films.Sort((first, second) => rule(first, second));
        }

        /// <summary>
        /// Подготовка аннотаций к фильмам при помощи внешней функции
        /// </summary>
        /// <param name="function">Функция с 1 параметром, применяемая ко всем элементам коллекции</param>
        /// <returns>Список с результатами применения функции</returns>
        public List<string> GetAnnotation(Func<T, string> function)
        {
            return _films.Select(function).ToList();
        }

        /// <summary>
        /// Применение стороннего метода ко всем элементам коллекции
        /// </summary>
        public void ApplyAction(Action<T> action)
        {
            foreach (var film in _films)
            {
                action(film);
            }
        }

        public int Count => _films.Count;
        public bool IsReadOnly => false;
    }
}