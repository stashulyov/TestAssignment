using System;
using GameData;
using Ui.StatUi;
using UnityEngine.UI;

namespace Common
{
    public interface IUiModel
    {
        event Action<int> OnButtonPressed;

        void AddStatPresenter(EStatType statUiType, StatUiPresenter presenter);
        void AddBuffPresenter(StatUiPresenter presenter);
        void AddButton(Button button);

        void SetStat(Stat stat);

        void ClearBuffs();
    }
}