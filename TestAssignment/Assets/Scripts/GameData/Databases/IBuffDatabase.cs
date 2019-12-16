namespace GameData
{
    public interface IBuffDatabase
    {
        int Count { get; }
        Buff GetRandomBuff();
    }
}