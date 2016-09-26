﻿using System;

namespace LabOneCinema.Artifacts
{
    /// <summary>
    /// Абстрактный класс для создаваемых во время съёмок сущностей
    /// </summary>
    public abstract class Artifact
    {
        public string Name { get; set; }
        public static EventArgs PseudoArgs = new EventArgs();  // не штампуем пустые списки аргументов без необходимости
    }
}
