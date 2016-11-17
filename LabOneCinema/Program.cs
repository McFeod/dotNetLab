using System;
using System.IO;
using CinemaLibrary.Logging;
using CinemaLibrary.Serialization;

namespace LabOneCinema
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            var logger = new Logger();
            PlaylistExtensions.Logger = logger;
            var serializer = new PlaylistXmlSerializer();

            var playlist = serializer.Deserialize(Path.Combine("..", "..", "films.xml"));

            Console.WriteLine(
                playlist.Filter(
                    (x) =>
                        x.Scenario.PageCount >= 80 &&
                        x.Scenario.PageCount < 100
                ).ToPlaylist().ConvertToString()
            );

            Console.WriteLine(
                playlist.LongFims().SmallCrewFilms().ConvertToString()
            );
        }

    }
}
