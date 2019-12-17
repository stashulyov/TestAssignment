namespace Players
{
    public interface IPlayerBuffsDetachedListener
    {
        void OnBuffsDetached(PlayerBuffsDetachedSignal signal);
    }
}