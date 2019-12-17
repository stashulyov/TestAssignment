using Players;

namespace Common
{
    public class DamageApplicator : IDamageApplicator
    {
        private readonly IPlayerModelDatabase _playerModelDatabase;

        public DamageApplicator(IPlayerModelDatabase playerModelDatabase)
        {
            _playerModelDatabase = playerModelDatabase;
        }

        public void ApplyDamage(int attackerId, int attackedId)
        {
            var attacker = _playerModelDatabase.Get(attackerId);
            var attacked = _playerModelDatabase.Get(attackedId);

            attacked.ApplyDamage(attacker.Damage);
        }
    }
}