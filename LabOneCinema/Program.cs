using System;
using System.Collections.Generic;
using System.IO;
using LabOneCinema.Artifacts;
using LabOneCinema.Logging;
using LabOneCinema.Serialization;

namespace LabOneCinema
{
    internal class Program : MainHelper
    {
        private static void Main(string[] args)
        {
            var filesLocation = Path.Combine("e:", "temp");
            // порядок обращения к файлам
            var fileOrder = new List<string>
            {
                "films_input.json",
                "films.xml",
                "films.bin",
                "films_output.json"
            };
            // порядок вызова сериализаторов
            var serializers = new List<IPlaylistSerializer<Film>>
            {
                new PlaylistJsonSerializer(),
                new PlaylistXmlSerializer(),
                new PlaylistBinarySerializer()
            };
            var logger = new ExceptionLogger();
            try
            {
                // десериализация/сериализация коллекции "по кольцу"
                for (var i=1; i<fileOrder.Count; ++i)
                {
                    // предыдущий сериализатор десериализует
                    var collection = serializers[(i-1) % serializers.Count]
                        .Deserialize(Path.Combine(filesLocation, fileOrder[i-1]));
                    // текущий сериализует
                    serializers[i % serializers.Count]
                        .Serialize(collection, Path.Combine(filesLocation, fileOrder[i]));
                }
            }
            catch (Exception e)
            {
                logger.HandleSystemException(e);
            }
            Console.WriteLine("Done");
        }
    }
}
