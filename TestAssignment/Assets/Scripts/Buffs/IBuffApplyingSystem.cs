using Players;

namespace Buffs
{
    public interface IBuffApplyingSystem
    {
        void ApplyBuffs(IPlayerModel playerModel);
    }
}