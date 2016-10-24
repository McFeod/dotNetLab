using LabOneCinema.Artifacts;
using LabOneCinema.Collections;
using LabOneCinema.Factory;
using LabOneCinema.Logging;

namespace CinemaTests
{
    /// <summary>
    /// Общие методы, используемые в разных тестах
    /// </summary>
    public class TestHelper
    {
        /// <summary>
        /// Получение примера коллекции фильмов
        /// </summary>
        /// <param name="logger">Логгер, передаваемый в фабрики</param>
        /// <param name="random">Случайный порядок обхода плейлиста</param>
        /// <returns>Плейлист</returns>
        public static Playlist<Film> GetPlaylist(FilmLogger logger=null, bool random=false)
        {
            var factoryLow = new LowBudgetFilmFactory(logger);
            var factoryHigh = new HighBudgetFilmFactory(logger);
            return new Playlist<Film>(random)
            {
                factoryLow.MakeFilm(
                    "Охотники за бургерами",
                    "Чапко Бронислава",
                    "Веселков Григорий",
                    "Петров Аристарх",
                    "Литвина Ева",
                    "Андронова Амина"
                ),
                factoryHigh.MakeFilm(
                    "Компиляция",
                    "Ушаков Виталий",
                    "Шершова Луиза",
                    "Соколов Вышеслав",
                    "Шалдыбин Степан",
                    "Наумова Юлия",
                    "Лебедев Митофан",
                    "Прокофьев Фрол",
                    "Русина Варвара"
                ),
                factoryLow.MakeFilm(
                    "Ржавчина",
                    "Захаров Евграф",
                    "Ушаков Роман",
                    "Дмитриева Каролина",
                    "Ильин Бернар"
                )
            };
        }
    }
}