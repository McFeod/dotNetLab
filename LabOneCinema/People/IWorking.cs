namespace LabOneCinema.People
{
    public interface IWorking<in T>
    {
        void DoWork(T artifact);
    }
}