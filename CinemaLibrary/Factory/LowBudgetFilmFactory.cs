﻿using CinemaLibrary.Logging;

namespace CinemaLibrary.Factory
{
    /// <summary>
    /// Фабрика для создания низкобюджетных фильмов
    /// </summary>
    public class LowBudgetFilmFactory: BaseBudgetFilmFactory
    {
        protected override double Factor { get; }

        public LowBudgetFilmFactory(FilmLogger logger = null): base(logger)
        {
            Factor = 1000;
        }
    }
}