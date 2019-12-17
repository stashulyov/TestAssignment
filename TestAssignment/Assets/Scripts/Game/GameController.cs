using Buffs;
using Players;

namespace Game
{
    public class GameController : IGameStartedListener
    {
        private readonly IPlayerModelInitializer _playerModelInitializer;
        private readonly IPlayerViewInitializer _playerViewInitializer;
        private readonly IPlayerModelDatabase _playerModelDatabase;
        private readonly IBuffApplyingSystem _buffApplyingSystem;

        public GameController(IPlayerModelInitializer playerModelInitializer, IPlayerViewInitializer playerViewInitializer, IPlayerModelDatabase playerModelDatabase,
            IBuffApplyingSystem buffApplyingSystem)
        {
            _playerModelInitializer = playerModelInitializer;
            _playerViewInitializer = playerViewInitializer;
            _playerModelDatabase = playerModelDatabase;
            _buffApplyingSystem = buffApplyingSystem;
        }

        public void OnGameStarted(GameStartedSignal signal)
        {
            foreach (var item in _playerModelDatabase.All)
            {
                var playerId = item.Key;

                _playerModelInitializer.InitializeModel(playerId);
                _playerViewInitializer.InitializeView(playerId);

                if (signal.AreBuffsEnabled)
                    _buffApplyingSystem.ApplyBuffs(playerId);
                else
                    _buffApplyingSystem.ClearBuffs(playerId);
            }
        }
    }
}