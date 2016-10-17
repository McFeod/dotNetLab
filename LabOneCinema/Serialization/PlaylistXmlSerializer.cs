using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using LabOneCinema.Artifacts;
using LabOneCinema.Collections;

namespace LabOneCinema.Serialization
{
    public class PlaylistXmlSerializer: IPlaylistSerializer<Film>
    {
        /// <summary>
        /// Стандартный XML сериализатор
        /// </summary>
        private readonly XmlSerializer _serializer;
        
        public PlaylistXmlSerializer()
        {
            _serializer = new XmlSerializer(typeof(Playlist<Film>));
        }

        /// <summary>
        /// Сериализация в XML
        /// </summary>
        /// <param name="playlist">Коллекция фильмов</param>
        /// <param name="outputFile">Выходной файл</param>
        public void Serialize(Playlist<Film> playlist, string outputFile)
        {
            using (var writer = new StreamWriter(outputFile))
            {
                _serializer.Serialize(writer, playlist);
            }
        }

        /// <summary>
        /// Десериализация из XML
        /// </summary>
        /// <param name="inputFile">Файл для чтения</param>
        /// <returns>Коллекция фильмов</returns>
        public Playlist<Film> Deserialize(string inputFile)
        {
            using (var sr = new StreamReader(inputFile))
            {
                return (Playlist<Film>)_serializer.Deserialize(sr);
            }
        }
    }
}