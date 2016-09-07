﻿using System.Collections.Generic;
using System.Linq;
using LabOneCinema.People;

namespace LabOneCinema.Artifacts
{
    /// <summary>
    /// Собственно, сам фильм
    /// </summary>
    public class Film: Artifact
    {
        /// <summary>
        /// Продолжительность фильма
        /// </summary>
        public double Duration { get; set; }

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
            Scenario = new Scenario();
        }

        /// <summary>
        /// Возвращает строку с описанием фильма и связанных сущностей
        /// </summary>
        public string Credits => $"Фильм: {Name}\n" +
                                 $"\tДлительность: {Duration} мин.\n" +
                                 $"\tСценарий: {Scenario.PageCount} стр.\n" +
                                 $"\tСценарист: {Writer.Name} (гонорар: {Writer.Salary}$)\n" +
                                 $"\tРежиссёр: {Producer.Name}(гонорар: {Writer.Salary}$\n" +
                                 $"\tАктёры:\n\t\t" +
            string.Join("\n\t\t", Artists.Select(i => $"{i.Name} (гонорар: {i.Salary}$"));
    }
}