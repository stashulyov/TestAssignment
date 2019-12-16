using System.Collections.Generic;
using GameData;
using Players;
using Signals;
using Ui.StatUi;
using Ui.UiModel;
using UnityEngine;

namespace Common
{
    public class UiModelUpdateSystem : IUiModelBuiltListener
    {
        private readonly IPlayerModelDatabase _playerModelDatabase;
        private readonly IUiModelDatabase _uiModelDatabase;
        private readonly IBuffUiDatabase _buffUiDatabase;
        private readonly IStatUiPool _statUiPool;
        private readonly IPlayerSceneProvider _playerSceneProvider;

        public UiModelUpdateSystem(IPlayerModelDatabase playerModelDatabase, IUiModelDatabase uiModelDatabase,
            IBuffUiDatabase buffUiDatabase, IStatUiPool statUiPool, IPlayerSceneProvider playerSceneProvider)
        {
            _playerModelDatabase = playerModelDatabase;
            _uiModelDatabase = uiModelDatabase;
            _buffUiDatabase = buffUiDatabase;
            _statUiPool = statUiPool;
            _playerSceneProvider = playerSceneProvider;
        }

        public void OnUiModelBuilt(UiModelBuiltSignal signal)
        {
            var playerModel = _playerModelDatabase.Get(signal.PlayerId);

            playerModel.OnChangeStat += OnChangeStat;
            playerModel.OnChangeBuffs += OnChangeBuffs;
        }

        private void OnChangeStat(int playerId, EStatType statType, float value)
        {
            _uiModelDatabase.Get(playerId).SetStat(new Stat(statType, value));
        }

        private void OnChangeBuffs(int playerId, List<Buff> buffs)
        {
            var uiModel = _uiModelDatabase.Get(playerId);
            uiModel.ClearBuffs();

            foreach (var buff in buffs)
            {
                Debug.LogError(buff.Type);

                var buffUi = _buffUiDatabase.Get(buff.Type);
                var presenter = _statUiPool.Spawn();

                presenter.SetIcon(buffUi.Icon);
                presenter.SetTitle(buffUi.Title);

                var parent = _playerSceneProvider.GetTransform(playerId);
                presenter.Attach(parent);

                uiModel.AddBuffPresenter(presenter);
            }
        }
    }
}