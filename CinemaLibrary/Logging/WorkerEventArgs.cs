using System;

namespace CinemaLibrary.Logging
{
    /// <summary>
    /// Тип результата деятельности работника
    /// </summary>
    public enum ArtifactType
    {
        FilmDuration,
        FilmItself,
        ScenarioLength
    }

    /// <summary>
    /// Аргументы события OnWork
    /// </summary>
    public class WorkerEventArgs: EventArgs
    {
        /// <summary>
        /// Тип работы
        /// </summary>
        public ArtifactType Type { get; set; }

        /// <summary>
        /// Количественная характеристика работы
        /// </summary>
        public double Measurement { get; set; }
    }
}