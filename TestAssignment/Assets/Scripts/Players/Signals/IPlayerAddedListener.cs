namespace Players
{
    public interface IPlayerAddedListener
    {
        void OnPlayerAdded(PlayerAddedSignal signal);
    }
}