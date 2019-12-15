using System;
using GameData;
using Ui.StatUi;
using UnityEngine.UI;

namespace Common
{
    public interface IUiModel
    {
        event Action<int> OnButtonPressed;

        int Id { get; }
        void AddPresenter(EStatType statUiType, StatUiPresenter presenter);
        void AddBuff(EBuffType buffType, StatUiPresenter presenter);
        void AddButton(Button button);

        void SetStat(Stat stat);
    }
}