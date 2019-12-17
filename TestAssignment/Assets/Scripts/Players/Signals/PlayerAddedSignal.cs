namespace Players
{
    public class PlayerAddedSignal
    {
        public readonly int PlayerId;

        public PlayerAddedSignal(int playerId)
        {
            PlayerId = playerId;
        }
    }
}