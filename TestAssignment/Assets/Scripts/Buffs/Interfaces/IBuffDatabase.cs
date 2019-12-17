using GameData;

namespace Buffs
{
    public interface IBuffDatabase
    {
        int Count { get; }
        Buff GetRandomBuff();
    }
}