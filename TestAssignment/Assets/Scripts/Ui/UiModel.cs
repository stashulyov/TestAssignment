using System.Collections.Generic;
using GameData;
using Ui.StatUi;

namespace Common
{
    public class UiModel : IUiModel
    {
        public int Id { get; }

        private Dictionary<EStatType, StatUiPresenter> _stats;
        private Dictionary<EBuffType, StatUiPresenter> _buffs;

        public UiModel(int id)
        {
            Id = id;
            
            _stats = new Dictionary<EStatType, StatUiPresenter>();
            _buffs = new Dictionary<EBuffType, StatUiPresenter>();
        }

        public void AddPresenter(EStatType statUiType, StatUiPresenter presenter)
        {
            _stats.Add(statUiType, presenter);
        }

        public void AddBuff(EBuffType buffType, StatUiPresenter presenter)
        {
            _buffs.Add(buffType, presenter);
        }

        public void SetStat(Stat stat)
        {
            _stats[stat.Type].SetValue(stat.Value);
        }
    }
}