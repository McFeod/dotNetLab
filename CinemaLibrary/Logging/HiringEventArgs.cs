using System;
using CinemaLibrary.Artifacts;
using CinemaLibrary.People;

namespace CinemaLibrary.Logging
{
    /// <summary>
    /// Параметры события найма
    /// </summary>
    public class HiringEventArgs: EventArgs
    {
        /// <summary>
        /// Нанятый работник
        /// </summary>
        public IWorking<Artifact> Hired { get; set; }
    }
}