using System;
using GameData;
using Ui.StatUi;
using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class UiBuilder : IUiBuilder
    {
        private readonly IUiModelFactory _uiModelFactory;
        private readonly IUiModelDatabase _uiModelDatabase;
        private readonly IStatUiDatabase _statUiDatabase;
        private readonly IStatUiFactory _statUiFactory;

        public UiBuilder(IUiModelFactory uiModelFactory, IUiModelDatabase uiModelDatabase, IStatUiDatabase statUiDatabase,
            IStatUiFactory statUiFactory)
        {
            _uiModelFactory = uiModelFactory;
            _uiModelDatabase = uiModelDatabase;
            _statUiDatabase = statUiDatabase;
            _statUiFactory = statUiFactory;
        }

        public void Build(int[] playerIds, Transform[] parents, Button[] attackButtons)
        {
            if (playerIds.Length != parents.Length || playerIds.Length != attackButtons.Length)
                throw new ArgumentOutOfRangeException(nameof(parents), "Count of players and panels are not equal.");

            for (int i = 0; i < playerIds.Length; i++)
            {
                var id = playerIds[i];
                var parent = parents[i];
                var attackButton = attackButtons[i];

                var uiModel = _uiModelFactory.Create(id);
                uiModel.AddButton(attackButton);

                foreach (var item in _statUiDatabase.All)
                {
                    var statUi = item.Value;
                    var statUiPresenter = _statUiFactory.Create();

                    statUiPresenter.SetIcon(statUi.Icon);
                    statUiPresenter.SetValue(0f);
                    statUiPresenter.Attach(parent);

                    uiModel.AddPresenter(statUi.Type, statUiPresenter);
                }

                _uiModelDatabase.Add(id, uiModel);
            }
        }
    }
}