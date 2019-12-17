using Players;

namespace Damage
{
    public interface IVampirismCalculator
    {
        float CalculateVampirism(IPlayerModel attacker, float damage);
    }
}