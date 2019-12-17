using System;
using System.Collections.Generic;
using GameData;
using UnityEngine.UI;

namespace Ui
{
    public class UiModel : IUiModel
    {
        public event Action<int> OnButtonPressed;
        private int Id { get; }

        private Dictionary<EStatType, StatUiPresenter> _stats;
        private List<StatUiPresenter> _buffs;

        public UiModel(int id)
        {
            Id = id;

            _stats = new Dictionary<EStatType, StatUiPresenter>();
            _buffs = new List<StatUiPresenter>();
        }

        public void AddStatPresenter(EStatType statUiType, StatUiPresenter presenter)
        {
            _stats.Add(statUiType, presenter);
        }

        public void AddBuffPresenter(StatUiPresenter presenter)
        {
            _buffs.Add(presenter);
        }

        public void AddButton(Button button)
        {
            button.onClick.AddListener(OnClick);
        }

        public void SetStat(Stat stat)
        {
            _stats[stat.Type].SetValue(stat.Value);
        }

        public void ClearBuffs()
        {
            foreach (var buff in _buffs)
                buff.Despawn();

            _buffs.Clear();
        }

        private void OnClick()
        {
            OnButtonPressed?.Invoke(Id);
        }
    }
}