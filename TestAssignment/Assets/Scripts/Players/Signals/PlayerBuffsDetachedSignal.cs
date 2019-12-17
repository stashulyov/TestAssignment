namespace Players
{
    public class PlayerBuffsDetachedSignal
    {
        public readonly int PlayerId;

        public PlayerBuffsDetachedSignal(int playerId)
        {
            PlayerId = playerId;
        }
    }
}