namespace Stats
{
    public class Stat
    {
        public readonly EStatType Type;
        public readonly float Value;

        public Stat(EStatType type, float value)
        {
            Type = type;
            Value = value;
        }
    }
}