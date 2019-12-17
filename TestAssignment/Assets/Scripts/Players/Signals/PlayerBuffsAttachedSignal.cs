using System.Collections.Generic;
using Buffs;
using GameData;

namespace Players
{
    public class PlayerBuffsAttachedSignal
    {
        public readonly int PlayerId;
        public readonly List<Buff> Buffs;

        public PlayerBuffsAttachedSignal(int playerId, List<Buff> buffs)
        {
            PlayerId = playerId;
            Buffs = buffs;
        }
    }
}