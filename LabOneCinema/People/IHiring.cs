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

        /// <summary>
        /// Событие, возникающее при найме сотрудника
        ///</summary>
        event EventHandler<HiringEventArgs> OnHire;
    }
}