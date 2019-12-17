using Players;

namespace Damage
{
    public interface IDamageCalculator
    {
        float CalculateDamage(IPlayerModel attacker, IPlayerModel attacked);
    }
}