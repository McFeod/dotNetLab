using System;
using System.IO;
using CinemaLibrary.Artifacts;
using CinemaLibrary.Exceptions;
using CinemaLibrary.Logging;
using CinemaLibrary.People;

namespace CinemaLibrary.Factory
{
    public class ConfigFilmFactory : BaseFilmFactory
    {
        public ConfigFilmFactory(FilmLogger logger = null) : base(logger)
        {
        }

        /// <summary>
        /// Загрузка "фильма" из файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Фильм</returns>
        /// <exception cref="NotEnoughPeopleException">
        /// Исключение, возникающее при чтении слишком коротких файлов
        /// </exception>
        /// <exception cref="NegativeValueException">
        /// Исключение, возникающее при неудачной валидации значений, которые заведомо неотрицательны
        /// </exception>
        public Film LoadFilm(string path)
        {
            var lines = File.ReadAllLines(path);
            if (lines.Length < 4)
                throw new NotEnoughPeopleException();

            // разбор названия и продолжительности фильма
            string filmName;
            var filmDuration =  ParseLine(lines[0], out filmName);
            if (filmDuration < 0)
            {
                throw new NegativeValueException("Продолжительность фильма не может быть отрицательной");
            }

            // разбор информации о режиссёре
            string name;

            var salary = ParseLine(lines[1], out name);
            if (salary < 0)
            {
                throw new NegativeValueException("Жалование режиссёра не может быть отрицательным");
            }
            var producer = new Producer(name) {Salary = salary};

            // разбор информации о сценаристе
            salary = ParseLine(lines[2], out name);
            if (salary < 0)
            {
                throw new NegativeValueException("Жалование сценариста не может быть отрицательным");
            }
            var writer = new Writer(name) {Salary = salary};

            // создание фильма
            var film = new Film(filmName, writer, producer);
            Logger?.SubscribeOnEvents(film);
            producer.DoWork(film);  // закомментировать для получения HiringOrderException
            writer.DoWork(film);
            film.Duration = (double)filmDuration;

            // разбор информации об актёрах
            for (var i = 3; i < lines.Length; ++i)
            {
                salary = ParseLine(lines[i], out name);
                if (salary < 0)
                {
                    throw new NegativeValueException("Жалование актёра не может быть отрицательным");
                }
                var artist = new Artist(name);
                producer.Hire(artist, salary);
            }

            return film;
        }

        /// <summary>
        /// Преобразование строки в кортеж из строки и числа
        /// </summary>
        /// <param name="line">исходная строка</param>
        /// <param name="firstPart">первая часть исходной строки</param>
        /// <returns>вторая часть исходной строки - число</returns>
        /// <exception cref="StringFormatException">
        /// Исключение, возникающее, когда в строке хранится что-то другое
        /// </exception>
        protected static decimal ParseLine(string line, out string firstPart)
        {
            var parts = line.Split(';');
            if (parts.Length != 2)
                throw new StringFormatException($"{line} : число аргументов не равно 2");
            firstPart = parts[0];
            try
            {
                var result = decimal.Parse(parts[1]);
                return result;
            }
            catch (Exception exception)
            {
                throw new StringFormatException(line, exception);
            }
        }
    }
}