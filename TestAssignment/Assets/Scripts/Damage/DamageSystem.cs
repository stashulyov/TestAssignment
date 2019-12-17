using System;
using Players;
using Ui;

namespace Damage
{
    public class DamageSystem : IUiModelBuiltListener
    {
        private readonly IUiModelDatabase _uiModelDatabase;
        private readonly IPlayerViewDatabase _playerViewDatabase;
        private readonly IDamageApplicator _damageApplicator;

        public DamageSystem(IUiModelDatabase uiModelDatabase, IPlayerViewDatabase playerViewDatabase, IDamageApplicator damageApplicator)
        {
            _uiModelDatabase = uiModelDatabase;
            _playerViewDatabase = playerViewDatabase;
            _damageApplicator = damageApplicator;
        }

        public void OnUiModelBuilt(UiModelBuiltSignal signal)
        {
            var uiModel = _uiModelDatabase.Get(signal.PlayerId);
            uiModel.OnButtonPressed += OnAttackPressed;
        }

        private void OnAttackPressed(int attackerId)
        {
            var attackerView = _playerViewDatabase.Get(attackerId);
            var attackedId = attackerView.GetEnemyId();

            if (attackedId == -1)
                throw new ArgumentException("There's no enemy.");

            attackerView.Attack();

            var attackedView = _playerViewDatabase.Get(attackedId);

            if (_damageApplicator.ApplyDamage(attackerId, attackedId))
                attackedView.Die();
        }
    }
}