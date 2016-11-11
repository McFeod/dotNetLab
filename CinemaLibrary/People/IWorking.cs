using System;
using CinemaLibrary.Artifacts;
using CinemaLibrary.Logging;

namespace CinemaLibrary.People
{
    /// <summary>
    /// Интерфейс работника
    /// </summary>
    /// <typeparam name="T">Тип сущности, над которой ведется работа</typeparam>
    public interface IWorking<out T>
    {
        T DoWork(Film film);

        /// <summary>
        /// Событие, возникающее при выполнении работы сотрудником
        ///</summary>
        event EventHandler<WorkerEventArgs> OnWork;
    }
}