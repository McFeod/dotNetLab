using System;
using System.IO;
using System.Threading;
using LabOneCinema.Artifacts;

namespace LabOneCinema.Logging
{
    /// <summary>
    /// Типы логируемых событий
    /// </summary>
    public enum EventType
    {
        WriterWorks,
        ArtistWorks,
        ProducerWorks,
        ProducerHires,
        FilmGrows,
        ScenarioGrows
    }

    /// <summary>
    /// Класс, собирающий события от разных частей программы в одно событие OnLog
    /// </summary>
    public class FilmLogger: Logger
    {
        /// <summary>
        /// Событие, возникающее при перехвате других событий и служащее для логирования
        /// </summary>
        public event EventHandler<LogEventArgs> OnLog = (sender, args) => {};

        /// <summary>
        /// Создание логгера с привязкой к файлу/консоли
        /// </summary>
        /// <param name="path">Путь к файлу. Если пуст/null - вывод пойдёт в консоль</param>
        public FilmLogger(string path=null): base(path)
        {
        }

        /// <summary>
        /// Пробрасываем все события, связанные с фильмом, в одно событие OnLog
        /// </summary>
        /// <param name="film">Фильм</param>
        public void SubscribeOnEvents(Film film)
        {
            film.Scenario.OnGrow += (sender, args) => HandleNested(sender, EventType.ScenarioGrows, args, film);
            film.Producer.OnWork += (sender, args) => HandleNested(sender, EventType.ProducerWorks, args, film);
            film.OnGrow += (sender, args) => HandleNested(sender, EventType.FilmGrows, args, film);
            film.Writer.OnWork += (sender, args) => HandleNested(sender, EventType.WriterWorks, args, film);
            film.Producer.OnHire += (sender, args) =>
            {
                HandleNested(sender, EventType.ProducerHires, args, film);
                args.Hired.OnWork +=
                    (artist, nestedArgs) => HandleNested(artist, EventType.ArtistWorks, nestedArgs, film);
            };
            foreach (var artist in film.Artists)
            {
                artist.OnWork += (sender, args) =>  HandleNested(artist, EventType.ArtistWorks, args, film);
            }
        }

        /// <summary>
        /// Упаковка аргументов для внешней функции печати. Нужный TextWriter прилагается
        /// </summary>
        /// <param name="obj">Объект, вызвавший событие</param>
        /// <param name="type">Тип события</param>
        /// <param name="args">Аргументы, с которыми было вызвано событие</param>
        /// <param name="film">Фильм, с которым связано событие</param>
        private void HandleNested(object obj, EventType type, EventArgs args, Film film)
        {
            using (var output = GetOutput())
            {
                OnLog(obj, new LogEventArgs()
                {
                    Nested = args,
                    Type = type,
                    Output = output,
                    Sender = film
                });
            }
        }
    }
}