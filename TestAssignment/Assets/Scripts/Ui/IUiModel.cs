using GameData;
using Ui.StatUi;

namespace Common
{
    public interface IUiModel
    {
        int Id { get; }
        void AddPresenter(EStatType statUiType, StatUiPresenter presenter);
        void AddBuff(EBuffType buffType, StatUiPresenter presenter);
        
        void SetStat(Stat stat);
    }
}