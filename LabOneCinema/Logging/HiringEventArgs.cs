using System;
using LabOneCinema.Artifacts;
using LabOneCinema.People;

namespace LabOneCinema.Logging
{
    public class HiringEventArgs: EventArgs
    {
        public IWorking<Artifact> Hired { get; set; }
    }
}