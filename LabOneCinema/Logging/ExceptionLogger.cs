using System;
using LabOneCinema.Exceptions;
using LabOneCinema.Factory;
using LabOneCinema.People;

namespace LabOneCinema.Logging
{
    public class ExceptionLogger: Logger
    {
        public ExceptionLogger(string path = null) : base(path)
        {
        }

        /// <summary>
        /// Обработка системных исключений
        /// </summary>
        /// <param name="exception"></param>
        public void HandleSystemException(Exception exception)
        {
            using (var output = GetOutput())
            {
                output.WriteLine($"{DateTime.Now}: Системное исключение {exception.ToString()}");
            }
        }

        /// <summary>
        /// Обработка пользовательских исключений
        /// </summary>
        /// <param name="exception"></param>
        public void HandleCustomException(CustomException exception)
        {
            using (var output = GetOutput())
            {
                output.WriteLine($"{DateTime.Now}: Пользовательское исключение {exception.ToString()}");
            }
        }
    }
}