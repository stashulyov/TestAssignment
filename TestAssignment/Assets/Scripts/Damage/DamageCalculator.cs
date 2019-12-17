using Players;

namespace Damage
{
    public class DamageCalculator : IDamageCalculator
    {
        public float CalculateDamage(IPlayerModel attacker, IPlayerModel attacked)
        {
            var damage = attacker.Damage;
            damage *= (1f - 0.01f * attacked.Armor);

            if (damage < 0f)
                return 0f;

            if (damage > attacked.Hp)
                return attacked.Hp;
            else
                return damage;
        }
    }
}