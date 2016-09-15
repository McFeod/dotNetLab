using LabOneCinema.Artifacts;

namespace LabOneCinema.People
{
    /// <summary>
    /// Пример использования ограничения типа, при котором тип должен иметь конструктор без параметров.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IStartingFromScratch<T> where T: Artifact, new()
    {
        void StartFromScratch(out T artifact);
    }
}