using System;
using LabOneCinema.Artifacts;

namespace LabOneCinema.People
{
    public class Writer: Person, IWorking<Scenario>
    {
        public Writer(string name) : base(name)
        {
        }

        public void DoWork(Scenario scenario)
        {
            scenario.PageCount += (ushort)Random.Next(20, 100);
        }
    }
}