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

        public void ApplyDamage(int playerId, float damage)
        {
            var player = _playerModelDatabase.Get(playerId);
            player.ApplyDamage(damage);
        }
    }
}