namespace Players
{
    public interface IPlayerModelFactory
    {
        IPlayerModel Create(int id);
    }
}