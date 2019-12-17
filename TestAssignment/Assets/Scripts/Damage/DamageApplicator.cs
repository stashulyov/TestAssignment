using Players;

namespace Damage
{
    public class DamageApplicator : IDamageApplicator
    {
        private readonly IPlayerModelDatabase _playerModelDatabase;
        private readonly IDamageCalculator _damageCalculator;
        private readonly IVampirismCalculator _vampirismCalculator;

        public DamageApplicator(IPlayerModelDatabase playerModelDatabase, IDamageCalculator damageCalculator, IVampirismCalculator vampirismCalculator)
        {
            _playerModelDatabase = playerModelDatabase;
            _damageCalculator = damageCalculator;
            _vampirismCalculator = vampirismCalculator;
        }

        public bool ApplyDamage(int attackerId, int attackedId)
        {
            var attacker = _playerModelDatabase.Get(attackerId);
            var attacked = _playerModelDatabase.Get(attackedId);

            var damage = _damageCalculator.CalculateDamage(attacker, attacked);
            var vampirism = _vampirismCalculator.CalculateVampirism(attacker, damage);
            attacked.Hp -= damage;
            attacker.Hp += vampirism;

            return attacked.Hp < float.Epsilon;
        }
    }
}