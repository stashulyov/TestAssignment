using Players;

namespace Ui
{
    public class UiModelStatUpdateSystem : IPlayerStatChangedListener
    {
        private readonly IUiModelDatabase _uiModelDatabase;

        public UiModelStatUpdateSystem(IUiModelDatabase uiModelDatabase)
        {
            _uiModelDatabase = uiModelDatabase;
        }
        
        public void OnPlayerStatChanged(PlayerStatChangedSignal signal)
        {
            var playerId = signal.PlayerId;
            var stat = signal.Stat;

            _uiModelDatabase.Get(playerId).SetStat(stat);
        }
    }
}