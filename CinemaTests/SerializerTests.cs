using LabOneCinema.Artifacts;
using LabOneCinema.Collections;
using LabOneCinema.People;
using Xunit;
using LabOneCinema.Serialization;

namespace CinemaTests
{
    /// <summary>
    /// Тесты на сериализацию и десериализацию
    /// </summary>
    public class SerializerTests
    {
        /// <summary>
        /// Коллекция, на которой будет проверяться сериализация
        /// </summary>
        private readonly Playlist<Film> _playlist;
        public SerializerTests()
        {
            _playlist = TestHelper.GetPlaylist();
        }

        /// <summary>
        /// Проверка сериализации/десериализации в JSON
        /// </summary>
        [Fact]
        public void TestJson()
        {
            var serializer = new PlaylistJsonSerializer();
            serializer.Serialize(_playlist, "playlist.json");
            var result = serializer.Deserialize("playlist.json");
            PlaylistComparation(result);
        }

        /// <summary>
        /// Проверка сериализации/десериализации в XML
        /// </summary>
        [Fact]
        public void TestXml()
        {
            var serializer = new PlaylistXmlSerializer();
            serializer.Serialize(_playlist, "playlist.xml");
            var result = serializer.Deserialize("playlist.xml");
            PlaylistComparation(result);
        }

        /// <summary>
        /// Проверка сериализации/десериализации в бинарный формат
        /// </summary>
        [Fact]
        public void TestBinary()
        {
            var serializer = new PlaylistBinarySerializer();
            serializer.Serialize(_playlist, "playlist.bin");
            var result = serializer.Deserialize("playlist.bin");
            PlaylistComparation(result);
        }

        /// <summary>
        /// Сравнение исходного и десериализованного плейлиста
        /// </summary>
        /// <param name="deserialized">Десериализованный лист</param>
        private void PlaylistComparation(Playlist<Film> deserialized)
        {
            Assert.NotNull(deserialized);
            Assert.Equal(deserialized.Count, _playlist.Count);
            var iter = deserialized.GetEnumerator();
            foreach (var film in _playlist)
            {
                iter.MoveNext();
                CompareFilms(iter.Current, film);
            }
            iter.Dispose();
        }

        /// <summary>
        /// Сравнение исходного и десериализованного фильма
        /// </summary>
        /// <param name="first">Исходный фильм</param>
        /// <param name="second">Десериализованный фильм</param>
        private static void CompareFilms(Film first, Film second)
        {
            Assert.Equal(first.Name, second.Name);
            ComparePeople(first.Writer, second.Writer);
            ComparePeople(first.Producer, second.Producer);
            Assert.Equal(first.Artists.Count, second.Artists.Count);
            var iter = first.Artists.GetEnumerator();
            foreach (var artist in second.Artists)
            {
                iter.MoveNext();
                ComparePeople(artist, iter.Current);
            }
            iter.Dispose();
        }

        /// <summary>
        /// Сравнение исходного и десериализованного сотрудника
        /// </summary>
        /// <param name="first">Исходный сотрудник</param>
        /// <param name="second">Десериализованный сотрудник</param>
        private static void ComparePeople(Person first, Person second)
        {
            Assert.Equal(first.Name, second.Name);
            Assert.Equal(first.Salary, second.Salary);
        }
    }
}