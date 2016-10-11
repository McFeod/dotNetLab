using System;
using LabOneCinema.Artifacts;
using LabOneCinema.People;

namespace LabOneCinema.Logging
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