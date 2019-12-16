using Players;
using UnityEngine;

namespace Common
{
    public class AttackUiSystem : IAttackUiSystem
    {
        private readonly IUiModelDatabase _uiModelDatabase;
        private readonly IPlayerViewDatabase _playerViewDatabase;
        private readonly IDamageApplicator _damageApplicator;

        public AttackUiSystem(IUiModelDatabase uiModelDatabase, IPlayerViewDatabase playerViewDatabase, IDamageApplicator damageApplicator)
        {
            _uiModelDatabase = uiModelDatabase;
            _playerViewDatabase = playerViewDatabase;
            _damageApplicator = damageApplicator;
        }

        public void Build()
        {
            foreach (var item in _uiModelDatabase.All)
            {
                item.Value.OnButtonPressed += OnButtonPressed;
            }
        }

        private void OnButtonPressed(int attacker)
        {
            Debug.LogError(attacker);

            var playerView = _playerViewDatabase.Get(attacker);
            var enemyId = playerView.GetEnemyId();

            _damageApplicator.ApplyDamage(enemyId, 10f);

            Debug.LogError(enemyId);
        }
    }
}