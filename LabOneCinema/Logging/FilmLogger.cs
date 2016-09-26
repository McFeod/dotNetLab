using System;
using System.IO;
using LabOneCinema.Artifacts;

namespace LabOneCinema.Logging
{
    public enum EventType
    {
        WriterWorks,
        ArtistWorks,
        ProducerWorks,
        ProducerHires,
        FilmGrows,
        ScenarioGrows
    }

    public class FilmLogger
    {
        public event EventHandler<LogEventArgs> OnLog = (sender, args) => {};

        private readonly bool _toFile;
        private readonly string _filename;

        /// <summary>
        /// Создание логгера с привязкой к файлу/консоли
        /// </summary>
        /// <param name="path">Путь к файлу. Если пуст/null - вывод пойдёт в консоль</param>
        public FilmLogger(string path=null)
        {
            _toFile = !string.IsNullOrEmpty(path);
            if (!_toFile) return;
            _filename = path;
            if (!File.Exists(_filename))
            {
                File.Create(_filename).Close();
            }
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
            using (var output = (_toFile ? File.AppendText(_filename) : Console.Out))
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