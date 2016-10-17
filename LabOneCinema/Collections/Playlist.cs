using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabOneCinema.Artifacts;
using LabOneCinema.Async;
using LabOneCinema.Delegates;
using Newtonsoft.Json;

namespace LabOneCinema.Collections
{
    /// <summary>
    /// Коллекция фильмов (или других производных от Artifact) на основе List,
    /// но со своим Enumerator-классом
    /// </summary>
    [Serializable]
    public class Playlist<T> : ICollection<T> where T: Artifact
    {
        [JsonRequired]
        private readonly List<T> _items;
        private readonly bool _isRandom;

        /// <summary>
        /// Конструктор, позволяющий создавать плейлисты с перемешиванием и без
        /// </summary>
        /// <param name="isRandom">Нужен ли случайный порядок элементов</param>
        public Playlist(bool isRandom)
        {
            _items = new List<T>();
            _isRandom = isRandom;

        }

        public Playlist(List<T> list, bool isRandom=false)
        {
            _items = list;
            _isRandom = isRandom;
        }

        public Playlist() : this(false){}

        public IEnumerator<T> GetEnumerator()
        {
            if (_isRandom)
                return new RandomEnumerator<T>(_items);
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _items.Remove(item);
        }

        /// <summary>
        /// Метод сортировки коллекции.
        /// </summary>
        /// <param name="rule">Делегат, определяющий операцию сравнения элементов</param>
        public void Sort(ComparsionRule<T> rule)
        {
            _items.Sort((first, second) => rule(first, second));
        }

        /// <summary>
        /// Запускает асинхронную сортировку коллекции
        /// </summary>
        /// <param name="rule">Делегат, определяющий операцию сравнения элементов</param>
        /// <param name="progressViever">Метод печати прогресса сортировки</param>
        public Task StartAsyncSort(ComparsionRule<T> rule, Action<string, double> progressViever)
        {
            return _items.HeapSort(rule, progressViever);
        }

        /// <summary>
        /// Подготовка аннотаций к фильмам при помощи внешней функции
        /// </summary>
        /// <param name="function">Функция с 1 параметром, применяемая ко всем элементам коллекции</param>
        /// <returns>Список с результатами применения функции</returns>
        public List<string> GetAnnotation(Func<T, string> function)
        {
            return _items.Select(function).ToList();
        }

        /// <summary>
        /// Применение стороннего метода ко всем элементам коллекции
        /// </summary>
        public void ApplyAction(Action<T> action)
        {
            foreach (var film in _items)
            {
                action(film);
            }
        }

        public int Count => _items.Count;
        public bool IsReadOnly => false;
    }
}