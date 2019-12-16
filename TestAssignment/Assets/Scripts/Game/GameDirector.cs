using Core;
using Players;
using Signals;

namespace Common
{
    public class GameDirector : IGameDirector, IInitializable
    {
        private readonly MonoBehaviourServiceLocator _monoBehaviourServiceLocator;
        private readonly IPlayerAddedBus _bus;

        private readonly IPlayerModelFactory _playerModelFactory;
        private readonly IPlayerModelDatabase _playerModelDatabase;
        private readonly IPlayerViewDatabase _playerViewDatabase;
        private readonly IPlayerSceneProvider _playerSceneProvider;
        private readonly IGameStartedBus _gameStartedBus;

        public GameDirector(MonoBehaviourServiceLocator monoBehaviourServiceLocator, IPlayerAddedBus bus,
            IPlayerModelFactory playerModelFactory, IPlayerModelDatabase playerModelDatabase, IPlayerViewDatabase playerViewDatabase,
            IPlayerSceneProvider playerSceneProvider, IGameStartedBus gameStartedBus)
        {
            _monoBehaviourServiceLocator = monoBehaviourServiceLocator;
            _bus = bus;
            _playerModelFactory = playerModelFactory;
            _playerModelDatabase = playerModelDatabase;
            _playerViewDatabase = playerViewDatabase;
            _playerSceneProvider = playerSceneProvider;
            _gameStartedBus = gameStartedBus;
        }

        public void Initialize()
        {
            _monoBehaviourServiceLocator.UiObjects.PlayWithBuffsButton.onClick.AddListener(PlayWithBuffs);
            _monoBehaviourServiceLocator.UiObjects.PlayWithoutBuffsButton.onClick.AddListener(PlayWithoutBuffs);

            BuildModels();
        }

        private void PlayWithBuffs()
        {
            _gameStartedBus.Fire(new GameStartedSignal(true));
        }

        private void PlayWithoutBuffs()
        {
            _gameStartedBus.Fire(new GameStartedSignal(false));
        }

        private void BuildModels()
        {
            var ids = new int[]
            {
                0, 1
            };

            foreach (var id in ids)
            {
                var playerView = _playerSceneProvider.GetView(id);
                var playerModel = _playerModelFactory.Create(id);

                _playerModelDatabase.Add(id, playerModel);
                _playerViewDatabase.Add(id, playerView);
                _bus.Fire(new PlayerAddedSignal(id));
            }
        }
    }
}