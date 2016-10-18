using System.Collections.Generic;
using System.IO;
using LabOneCinema.Artifacts;
using LabOneCinema.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LabOneCinema.Serialization
{
    /// <summary>
    /// Сериализатор коллекции фильмов, использующий JSON формат
    /// </summary>
    public class PlaylistJsonSerializer: IPlaylistSerializer<Film>
    {
        /// <summary>
        /// Используется сериализатор из Newtonsoft.JSON
        /// </summary>
        private readonly JsonSerializer  _serializer;

        public PlaylistJsonSerializer()
        {
            _serializer = new JsonSerializer();
            _serializer.Converters.Add(new JavaScriptDateTimeConverter());
            _serializer.NullValueHandling = NullValueHandling.Ignore;
            _serializer.Formatting = Formatting.Indented;
        }

        /// <summary>
        /// Сериализация в JSON
        /// </summary>
        /// <param name="playlist">Коллекция фильмов</param>
        /// <param name="outputFile">Выходной файл</param>
        public void Serialize(Playlist<Film> playlist, string outputFile)
        {
            using (var sw = new StreamWriter(outputFile))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                _serializer.Serialize(writer, playlist);
            }
        }

        /// <summary>
        /// Десериализация из JSON
        /// </summary>
        /// <param name="inputFile">Файл с JSON</param>
        /// <returns>Коллекция фильмов</returns>
        public Playlist<Film> Deserialize(string inputFile)
        {
            using (var sr = new StreamReader(inputFile))
            using (var jsonTextReader = new JsonTextReader(sr))
            {
                var films = _serializer.Deserialize<List<Film>>(jsonTextReader);

                return new Playlist<Film>(films);
            }
        }
    }
}