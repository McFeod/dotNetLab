using System;
using LabOneCinema.Artifacts;
using LabOneCinema.Logging;

namespace LabOneCinema.People
{
    /// <summary>
    /// Интерфейс работника
    /// </summary>
    /// <typeparam name="T">Тип сущности, над которой ведется работа</typeparam>
    public interface IWorking<out T>
    {
        T DoWork(Film film);
        event EventHandler<WorkerEventArgs> OnWork;
    }
}