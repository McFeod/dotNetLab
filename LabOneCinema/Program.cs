using System;
using System.IO;
using LabOneCinema.Exceptions;
using LabOneCinema.Factory;
using LabOneCinema.Logging;

namespace LabOneCinema
{
    internal class Program: MainHelper
    {
        private static void Main(string[] args)
        {
            var logger = new FilmLogger(Path.Combine("..", "..", "films.log"));
            logger.OnLog += PrintToLog;

            var exceptionLogger = new ExceptionLogger();

            var factory = new ConfigFilmFactory(logger);

            try
            {
                var film = factory.LoadFilm(Path.Combine("..", "..", "Assets", "film_1.csv"));
                Console.WriteLine(film.Credits);
            }
            catch (CustomException exception)
            {
                exceptionLogger.HandleCustomException(exception);
            }
            catch (Exception exception)
            {
                exceptionLogger.HandleSystemException(exception);
            }
        }
    }
}
