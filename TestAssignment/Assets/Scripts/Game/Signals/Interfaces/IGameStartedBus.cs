namespace Game
{
    public interface IGameStartedBus
    {
        void Fire(GameStartedSignal signal);
    }
}