using GameData;
using Stats;

namespace Buffs
{
    public class BuffStat
    {
        public readonly EStatType Type;
        public readonly float Value;

        public BuffStat(EStatType type, float value)
        {
            Type = type;
            Value = value;
        }
    }
}