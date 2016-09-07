using System;
using LabOneCinema.Factory;

namespace LabOneCinema
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var factoryLow = new LowBudgetFilmFactory();
            var factoryHigh = new HighBudgetFilmFactory();
            var filmOne = factoryLow.MakeFilm(
                "Охотники за бургерами",
                "Чапко Бронислава",
                "Веселков Григорий",
                "Петров Аристарх",
                "Литвина Ева",
                "Андронова Амина"
            );
            var filmTwo = factoryHigh.MakeFilm(
                "Компиляция",
                "Ушаков Виталий",
                "Шершова Луиза",
                "Соколов Вышеслав",
                "Шалдыбин Степан",
                "Наумова Юлия",
                "Лебедев Митофан",
                "Прокофьев Фрол",
                "Русина Варвара"
            );
            Console.WriteLine(filmOne.Credits);
            Console.WriteLine("===============================================================================");
            Console.WriteLine(filmTwo.Credits);
            Console.ReadKey();
        }
    }
}
