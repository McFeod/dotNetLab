using System;
using CinemaLibrary;
using CinemaLibrary.Factory;

namespace LabOneCinema
{
    internal class Program : MainHelper
    {
        private static void Main(string[] args)
        {
            var factory = new HighBudgetFilmFactory();
            var film = factory.MakeFilm(
                "Пример", "Захаров Евграф", "Ушаков Роман", "Дмитриева Каролина", "Ильин Бернар");
            Console.WriteLine(film.Credits);
        }
    }
}
