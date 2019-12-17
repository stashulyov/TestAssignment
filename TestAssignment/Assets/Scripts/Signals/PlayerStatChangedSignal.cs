using GameData;

namespace Signals
{
    public class PlayerStatChangedSignal
    {
        public readonly int PlayerId;
        public readonly Stat Stat;

        public PlayerStatChangedSignal(int playerId, Stat stat)
        {
            PlayerId = playerId;
            Stat = stat;
        }
    }
}