using System;
using System.Collections.Generic;
using System.Linq;

namespace LabOneCinema
{
    public class MainHelper
    {
        public static void PrintProperties<T>(IEnumerable<T> list, string property, string separator)
        {
            Console.WriteLine(string.Join(separator,
                list.Select(x => x.GetType().GetProperty(property).GetValue(x, null))
            ));
        }
    }
}