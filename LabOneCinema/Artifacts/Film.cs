using System;
using System.Collections.Generic;
using System.Linq;
using LabOneCinema.People;

namespace LabOneCinema.Artifacts
{
    /// <summary>
    /// Собственно, сам фильм
    /// </summary>
    public class Film: Artifact, ICloneable
    {
        /// <summary>
        /// Событие, вызываемое при увеличении длины фильма
        /// </summary>
        public event EventHandler OnGrow = (sender, pseudoArgs) => { };

        /// <summary>
        /// Продолжительность фильма
        /// </summary>
        private double _duration;
        public double Duration {
            get { return _duration; }
            set
            {
                _duration = value;
                OnGrow(this, PseudoArgs);
            }
        }

        /// <summary>
        /// Сценарий фильма
        /// </summary>
        internal Scenario Scenario;

        /// <summary>
        /// Сценарист
        /// </summary>
        internal Writer Writer;

        /// <summary>
        /// Режиссёр
        /// </summary>
        internal Producer Producer;

        /// <summary>
        /// Актёры
        /// </summary>
        internal List<Artist> Artists;

        public Film(string name, Writer writer, Producer producer)
        {
            Name = name;
            Writer = writer;
            Producer = producer;
            Artists = new List<Artist>();
            Scenario = new Scenario(){Name = $"Сценарий к фильму \"{Name}\""};
        }

        /// <summary>
        /// Возвращает строку с описанием фильма и связанных сущностей
        /// </summary>
        public string Credits => $"Фильм: {Name}\n" +
                                 $"\tДлительность: {Duration} мин.\n" +
                                 $"\tСценарий: {Scenario.PageCount} стр.\n" +
                                 $"\tСценарист: {Writer.Name} (гонорар: {Writer.Salary}$)\n" +
                                 $"\tРежиссёр: {Producer.Name}(гонорар: {Writer.Salary}$)\n" +
                                 $"\tАктёры:\n\t\t" +
            string.Join("\n\t\t", Artists.Select(i => $"{i.Name} (гонорар: {i.Salary}$)"));

        public object Clone()
        {
            var result = new Film(this.Name, this.Writer, this.Producer);
            result.Artists.AddRange(this.Artists);
            result.Duration = this.Duration;
            result.Scenario.PageCount = this.Scenario.PageCount;
            result.Scenario.Name = this.Scenario.Name;
            return result;
        }
    }
}