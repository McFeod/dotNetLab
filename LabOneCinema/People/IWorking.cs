namespace LabOneCinema.People
{
    /// <summary>
    /// Интерфейс работника
    /// </summary>
    /// <typeparam name="T">Тип сущности, над которой ведется работа</typeparam>
    public interface IWorking<T>
    {
        void DoWork(T artifact);
    }
}