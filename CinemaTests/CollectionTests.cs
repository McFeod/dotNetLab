using CinemaLibrary;
using Xunit;

namespace CinemaTests
{
    /// <summary>
    /// Тесты для методов, специфичных для плейлиста
    /// </summary>
    public class CollectionTests
    {
        /// <summary>
        /// Проверка работы кастомного Enumerator'a
        /// </summary>
        [Fact]
        public void EnumeratorTest()
        {
            var playlist = TestHelper.GetPlaylist(random: true);
            var counter = 0;
            foreach (var film in playlist)
            {
                counter++;
            }
            Assert.Equal(counter, playlist.Count);
        }

        /// <summary>
        /// Проверка работы примеров, иллюстрирующих Action и Func
        /// </summary>
        [Fact]
        public void DelegateTest()
        {
            var playlist = TestHelper.GetPlaylist();
            playlist.ApplyAction(MainHelper.PrintBudget);
            Assert.NotEmpty(playlist.GetAnnotation(MainHelper.RandomArtist));
        }

    }
}