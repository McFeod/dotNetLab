using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CinemaLibrary.Artifacts;
using CinemaLibrary.Collections;

namespace CinemaLibrary.Serialization
{
    /// <summary>
    /// Сериализатор коллекции фильмов, использующий бинарный формат
    /// </summary>
    public class PlaylistBinarySerializer:IPlaylistSerializer<Film>
    {
        /// <summary>
        /// Стандартный бинарный сериализатор
        /// </summary>
        private readonly BinaryFormatter _serializer;

        public PlaylistBinarySerializer()
        {
            _serializer = new BinaryFormatter();
        }

        /// <summary>
        /// Сериализация в бинарный формат
        /// </summary>
        /// <param name="playlist">Коллекция фильмов</param>
        /// <param name="outputFile">Файл для записи</param>
        public void Serialize(Playlist<Film> playlist, string outputFile)
        {
            using (var stream = new FileStream(outputFile, FileMode.Create))
            {
                _serializer.Serialize(stream, playlist);
            }
        }

        /// <summary>
        /// Десериализация из бинарного формата
        /// </summary>
        /// <param name="inputFile">Файл для чтения</param>
        /// <returns>Коллекция фильмов</returns>
        public Playlist<Film> Deserialize(string inputFile)
        {
            using (var stream = new FileStream(inputFile, FileMode.Open))
            {
                return (Playlist<Film>)_serializer.Deserialize(stream);
            }
        }
    }
}