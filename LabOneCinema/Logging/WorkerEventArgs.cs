using System;

namespace LabOneCinema.Logging
{
    public enum ArtifactType
    {
        FilmDuration,
        FilmItself,
        ScenarioLength
    }
    public class WorkerEventArgs: EventArgs
    {
        public ArtifactType Type { get; set; }
        public double Measurement { get; set; }
    }
}