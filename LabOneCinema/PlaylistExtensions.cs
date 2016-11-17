using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CinemaLibrary.Artifacts;
using CinemaLibrary.Collections;
using CinemaLibrary.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LabOneCinema
{
    /// <summary>
    /// Набор методов-расширений для класса Playlist
    /// </summary>
    public static class PlaylistExtensions
    {
        /// <summary>
        /// Логирование в методах-расширениях
        /// </summary>
        public static Logger Logger { get; set; }

        private static readonly JsonSerializer Serializer;

        static PlaylistExtensions()
        {
            Serializer = new JsonSerializer();
            Serializer.Converters.Add(new JavaScriptDateTimeConverter());
            Serializer.NullValueHandling = NullValueHandling.Ignore;
            Serializer.Formatting = Formatting.Indented;
        }

        /// <summary>
        /// Сериализация коллекции в строку в формате json
        /// </summary>
        /// <param name="playlist">Коллекция</param>
        /// <typeparam name="T">Тип элементов коллекции</typeparam>
        /// <returns>Строка с сериализованной коллекцией</returns>
        public static string ConvertToString<T>(this IEnumerable<T> playlist) where T : Artifact
        {
            Logger?.Log("Сериализация коллекции");
            var writer = new StringWriter();
            Serializer.Serialize(writer, playlist);
            return writer.ToString();
        }


        /// <summary>
        /// Фильтрация коллекции элементов по заданному условию
        /// </summary>
        /// <param name="collection">Коллекция</param>
        /// <param name="condition">Условие отбора</param>
        /// <typeparam name="T">Тип элементов коллекции</typeparam>
        /// <returns>Коллекция элементов, удовлетворяющая устовию отбора</returns>
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection,
            Func<T, bool> condition)
        {
            Logger?.Log("Фильтрация коллекции");
//            return collection.Where(condition);
            return collection._myWhere(condition);
        }

        /// <summary>
        /// Создание плейлиста из коллекции фильмов/других наследников Artifact
        /// </summary>
        /// <param name="playlist">Исходная коллекция</param>
        /// <typeparam name="T">Тип элементов коллекции</typeparam>
        /// <returns>Плейлист</returns>
        public static Playlist<T> ToPlaylist<T>(this IEnumerable<T> playlist) where T: Artifact
        {
            Logger?.Log("Преобразование коллекции в плейлист");
            var result = new Playlist<T>();
            foreach (var item in playlist)
            {
                result.Add(item);
            }
            return result;
        }


        /// <summary>
        /// Фильтр коллекции фильмов, прячущий фильмы с длиной менее часа
        /// </summary>
        /// <param name="playlist">Коллекция фильмов</param>
        /// <returns>Отфильтрованная коллекция фильмов</returns>
        public static IEnumerable<Film> LongFims(this IEnumerable<Film> playlist)
        {
            var result = playlist.Filter((x) => x.Duration >= 60);
            Logger?.Log("Условие отбора: длина более часа");
            return result;
        }

        /// <summary>
        /// Фильтр коллекции фильмов, показывающий фильмы с небольшим числом актеров
        /// </summary>
        /// <param name="playlist">Коллекция фильмов</param>
        /// <returns>Отфильтрованная коллекция фильмов</returns>
        public static IEnumerable<Film> SmallCrewFilms(this IEnumerable<Film> playlist)
        {
            var result = playlist.Filter((x) => x.Artists.Count < 4);
            Logger?.Log("Условие отбора: мало актёров");
            return result;
        }

        /// <summary>
        /// Аналог LINQ Where
        /// </summary>
        /// <param name="collection">Коллекция, к которой применяется условие</param>
        /// <param name="condition">Условие</param>
        /// <typeparam name="T">Тип элементов</typeparam>
        /// <returns>Новая коллекция</returns>
        private static IEnumerable<T> _myWhere<T>(this IEnumerable<T> collection,
            Func<T, bool> condition)
        {
            foreach (var item in collection)
            {
                if (condition(item))
                {
                    yield return item;
                }
            }
        }
    }
}