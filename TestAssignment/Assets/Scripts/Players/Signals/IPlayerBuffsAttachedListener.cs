namespace Players
{
    public interface IPlayerBuffsAttachedListener
    {
        void OnBuffsAttached(PlayerBuffsAttachedSignal signal);
    }
}