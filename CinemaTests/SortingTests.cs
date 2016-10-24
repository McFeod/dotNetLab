using System;
using System.Collections.Generic;
using LabOneCinema.Artifacts;
using LabOneCinema.Async;
using LabOneCinema.Collections;
using LabOneCinema.Delegates;
using Xunit;

namespace CinemaTests
{
    /// <summary>
    /// Тесты на сортировку коллекции
    /// </summary>
    public class SortingTests
    {
        /// <summary>
        /// Плейлист для тестов
        /// </summary>
        private readonly Playlist<Film> _playlist = TestHelper.GetPlaylist();

        /// <summary>
        /// Тест на корректность пирамидальной сортировки
        /// </summary>
        [Fact]
        public void TestHeapSort()
        {
            var random = new Random();
            var collection = new List<int>();
            for (var i = 0; i < 100; ++i)
            {
                collection.Add(random.Next());
            }
            var task = collection.HeapSort((a, b) => a.CompareTo(b), (s, d) => { });
            task.Wait();
            for (var i = 1; i < 100; ++i)
            {
                Assert.True(collection[i-1] < collection[i]);
            }
        }

        /// <summary>
        /// Проверка сортировок плейлиста с различными компараторами
        /// </summary>
        [Fact]
        public void TestSortOrders()
        {
            _playlist.Sort(FilmComparsion.ArtistCountOrder);
            TestOrder(FilmComparsion.ArtistCountOrder);
            _playlist.Sort(FilmComparsion.DurationOrder);
            TestOrder(FilmComparsion.DurationOrder);
            _playlist.Sort(FilmComparsion.ProducerNameOrder);
            TestOrder(FilmComparsion.ProducerNameOrder);
        }

        /// <summary>
        /// Проверка правильности расположения элементов плейлиста после сортировки
        /// </summary>
        /// <param name="rule">Компаратор</param>
        private void TestOrder(ComparsionRule<Film> rule)
        {
            var iter = _playlist.GetEnumerator();
            iter.MoveNext();
            var last = iter.Current;
            while (iter.MoveNext())
            {
                Assert.True(rule(last, iter.Current) <= 0);
                last = iter.Current;
            }
            iter.Dispose();
        }
    }
}