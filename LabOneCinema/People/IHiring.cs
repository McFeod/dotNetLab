using System;
using LabOneCinema.Logging;

namespace LabOneCinema.People
{
    /// <summary>
    /// Интерфейс, реализующий найм актёров
    /// </summary>
    public interface IHiring<in T> where T: Person
    {
        void Hire(T person, decimal salary);
        event EventHandler<HiringEventArgs> OnHire;
    }
}