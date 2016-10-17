﻿using LabOneCinema.Artifacts;
using LabOneCinema.Collections;

namespace LabOneCinema.Serialization
{
    /// <summary>
    /// Общий интерфейс для классов сериализации/десериализации плейлистов
    /// </summary>
    /// <typeparam name="T">Тип элементов коллекции</typeparam>
    public interface IPlaylistSerializer<T> where T : Artifact
    {
        void Serialize(Playlist<T> playlist, string outputFile);
        Playlist<T> Deserialize(string inputFile);
    }
}