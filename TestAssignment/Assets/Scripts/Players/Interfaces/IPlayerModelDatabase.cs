namespace Players
{
    public interface IPlayerModelDatabase
    {
        void Add(int id, IPlayerModel model);
        IPlayerModel Get(int id);
    }
}