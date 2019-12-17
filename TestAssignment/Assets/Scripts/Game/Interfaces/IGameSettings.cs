namespace Game
{
    public interface IGameSettings
    {
        bool AllowDuplicateBuffs { get; }
        int BuffCountMin { get; }
        int BuffCountMax { get; }
    }
}