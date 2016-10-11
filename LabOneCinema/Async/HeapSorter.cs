using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LabOneCinema.Delegates;

namespace LabOneCinema.Async
{
    public static class HeapSorter
    {
        private const string FirstStageMsg = "Heap preparation";
        private const string SecondStageMsg = "Sorting";

        /// <summary>
        /// Пирамидальная сортировка
        /// </summary>
        /// <param name="collection">Коллекция на основе массива (для обеспечения n*log(n))</param>
        /// <param name="rule">Компаратор</param>
        /// <param name="progressViewer">Внешний метод для визуализации прогресса</param>
        /// <typeparam name="T">Тип элементов коллекции</typeparam>
        public static async Task HeapSort<T>(this IList<T> collection, ComparsionRule<T> rule,
            Action<string, double> progressViewer)
        {
            for (var idx = collection.Count/2 - 1; idx >= 0; idx--)
            {
                await RestoreHeap(collection, idx, collection.Count, rule);
                progressViewer(FirstStageMsg, 1 - 2*(double)idx/collection.Count);
            }

            for (var idx = collection.Count - 1; idx >= 1; idx--)
            {
                collection.Swap(0, idx);
                await RestoreHeap(collection, 0, idx, rule);
                progressViewer(SecondStageMsg, 1 - (double)idx/collection.Count);
            }
            progressViewer(SecondStageMsg, 1);
        }

        /// <summary>
        /// Восстановление порядка следования родительских и дочерних элементов в бинарной куче
        /// </summary>
        /// <param name="collection">Бинарная куча</param>
        /// <param name="root">Элемент, с которого начинается проверка</param>
        /// <param name="bound">Элемент, на котором заканчивается проверка</param>
        /// <param name="rule">Правило сравнения элементов кучи</param>
        /// <typeparam name="T">Тип элементов кучи</typeparam>
        private static async Task RestoreHeap<T>(IList<T> collection, int root, int bound, ComparsionRule<T> rule)
        {
            await Task.Run(() =>
            {
                while (root * 2 + 1 < bound)
                {
                    var leftChildIdx = root * 2 + 1;
                    var rightChildIdx = (leftChildIdx < bound - 1) ? leftChildIdx + 1 : leftChildIdx;
                    var maxChildIdx = (rule(collection[leftChildIdx], collection[rightChildIdx]) >= 0
                        ? leftChildIdx
                        : rightChildIdx);
                    if (rule(collection[root], collection[maxChildIdx]) < 0)
                    {
                        collection.Swap(maxChildIdx, root);
                        root = maxChildIdx;
                    }
                    else return;
                }
//                Thread.Sleep(1);
            });
        }

        /// <summary>
        /// Метод-расширение для обмена 2 элементов коллекции по индексу
        /// </summary>
        /// <param name="collection">Коллекция</param>
        /// <param name="firstIdx">Индекс первого элемента</param>
        /// <param name="secondIdx">Индекс второго элемента</param>
        /// <typeparam name="T">Тип элементов коллекции</typeparam>
        public static void Swap<T>(this IList<T> collection, int firstIdx, int secondIdx)
        {
            var temp = collection[firstIdx];
            collection[firstIdx] = collection[secondIdx];
            collection[secondIdx] = temp;
        }
    }
}