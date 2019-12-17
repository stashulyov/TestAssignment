namespace Buffs
{
    public class Buff
    {
        public readonly EBuffType Type;
        public readonly BuffStat[] Stats;

        public Buff(EBuffType type, BuffStat[] stats)
        {
            Type = type;
            Stats = stats;
        }
    }
}