using Players;

namespace Damage
{
    public class VampirismCalculator : IVampirismCalculator
    {
        public float CalculateVampirism(IPlayerModel attacker, float damage)
        {
            var vampirismFactor = 0.01f * attacker.Vampirism;
            return damage * vampirismFactor;
        }
    }
}