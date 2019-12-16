using GameData;
using Players;
using Signals;
using Ui.UiModel;

namespace Common
{
    public class UiModelUpdateSystem : IUiModelBuiltListener
    {
        private readonly IPlayerModelDatabase _playerModelDatabase;
        private readonly IUiModelDatabase _uiModelDatabase;

        public UiModelUpdateSystem(IPlayerModelDatabase playerModelDatabase, IUiModelDatabase uiModelDatabase)
        {
            _playerModelDatabase = playerModelDatabase;
            _uiModelDatabase = uiModelDatabase;
        }

        public void OnUiModelBuilt(UiModelBuiltSignal signal)
        {
            var playerModel = _playerModelDatabase.Get(signal.PlayerId);

            playerModel.OnChangeStat += OnChangeStat;
        }

        private void OnChangeStat(int playerId, EStatType statType, float value)
        {
            _uiModelDatabase.Get(playerId).SetStat(new Stat(statType, value));
        }
    }
}