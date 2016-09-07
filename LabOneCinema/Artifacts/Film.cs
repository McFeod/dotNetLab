using System.Collections.Generic;
using System.Linq;
using LabOneCinema.People;

namespace LabOneCinema.Artifacts
{
    public class Film: Artifact
    {
        public double Duration { get; set; }
        internal Scenario Scenario;
        internal Writer Writer;
        internal Producer Producer;
        internal List<Artist> Artists;

        public Film(string name, Writer writer, Producer producer)
        {
            Name = name;
            Writer = writer;
            Producer = producer;
            Artists = new List<Artist>();
            Scenario = new Scenario();
        }

        public string Credits => $"Фильм: {Name}\n" +
                                 $"\tДлительность: {Duration} мин.\n" +
                                 $"\tСценарий: {Scenario.PageCount} стр.\n" +
                                 $"\tСценарист: {Writer.Name} (гонорар: {Writer.Salary}$)\n" +
                                 $"\tРежиссёр: {Producer.Name}(гонорар: {Writer.Salary}$\n" +
                                 $"\tАктёры:\n\t\t" +
            string.Join("\n\t\t", Artists.Select(i => $"{i.Name} (гонорар: {i.Salary}$"));
    }
}