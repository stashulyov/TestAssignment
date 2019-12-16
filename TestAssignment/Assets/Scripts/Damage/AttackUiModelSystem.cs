using Players;
using Signals;
using Ui.UiModel;
using UnityEngine;

namespace Common
{
    public class AttackUiModelSystem : IUiModelBuiltListener
    {
        private readonly IUiModelDatabase _uiModelDatabase;
        private readonly IPlayerViewDatabase _playerViewDatabase;
        private readonly IDamageApplicator _damageApplicator;

        public AttackUiModelSystem(IUiModelDatabase uiModelDatabase, IPlayerViewDatabase playerViewDatabase, IDamageApplicator damageApplicator)
        {
            _uiModelDatabase = uiModelDatabase;
            _playerViewDatabase = playerViewDatabase;
            _damageApplicator = damageApplicator;
        }

        public void OnUiModelBuilt(UiModelBuiltSignal signal)
        {
            var uiModel = _uiModelDatabase.Get(signal.PlayerId);
            uiModel.OnButtonPressed += OnButtonPressed;
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