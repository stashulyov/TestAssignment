using GameData;
using Players;

namespace Buffs
{
    public interface IBuffApplicator
    {
        void Apply(IPlayerModel model, Buff buff);
    }
}