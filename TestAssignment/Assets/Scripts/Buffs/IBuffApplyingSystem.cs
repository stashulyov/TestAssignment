namespace Buffs
{
    public interface IBuffApplyingSystem
    {
        void ApplyBuffs(int playerId);
        void ClearBuffs(int playerId);
    }
}