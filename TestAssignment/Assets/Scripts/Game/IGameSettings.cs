namespace Buffs
{
    public interface IGameSettings
    {
        bool AllowDuplicateBuffs { get; }
        int BuffCountMin { get; }
        int BuffCountMax { get; }
    }
}