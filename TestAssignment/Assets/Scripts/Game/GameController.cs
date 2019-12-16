using Players;
using Signals;

namespace Buffs
{
    public class GameController : IGameStartedListener
    {
        private readonly IPlayerModelInitializer _playerModelInitializer;
        private readonly IPlayerModelDatabase _playerModelDatabase;
        private readonly IBuffApplyingSystem _buffApplyingSystem;

        public GameController(IPlayerModelInitializer playerModelInitializer, IPlayerModelDatabase playerModelDatabase,
            IBuffApplyingSystem buffApplyingSystem)
        {
            _playerModelInitializer = playerModelInitializer;
            _playerModelDatabase = playerModelDatabase;
            _buffApplyingSystem = buffApplyingSystem;
        }

        public void OnGameStarted(GameStartedSignal signal)
        {
            foreach (var item in _playerModelDatabase.All)
            {
                var playerModel = item.Value;

                _playerModelInitializer.InitializeModel(playerModel);

                if (signal.AreBuffsEnabled)
                    _buffApplyingSystem.ApplyBuffs(playerModel);
            }
        }
    }
}