namespace LabOneCinema.People
{
    /// <summary>
    /// Интерфейс, реализующий найм актёров
    /// </summary>
    public interface IHiring
    {
        void Hire(Artist artist, decimal salary);
    }
}