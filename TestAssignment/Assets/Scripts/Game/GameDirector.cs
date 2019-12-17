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
        private readonly IGameStartedBus _gameStartedBus;
        private readonly IPlayerStatChangedBus _playerStatChangedBus;
        private readonly IPlayerViewFactory _playerViewFactory;

        public GameDirector(MonoBehaviourServiceLocator monoBehaviourServiceLocator, IPlayerAddedBus bus, IPlayerModelFactory playerModelFactory,
            IPlayerModelDatabase playerModelDatabase, IPlayerViewDatabase playerViewDatabase, IGameStartedBus gameStartedBus,
            IPlayerStatChangedBus playerStatChangedBus, IPlayerViewFactory playerViewFactory)
        {
            _monoBehaviourServiceLocator = monoBehaviourServiceLocator;
            _bus = bus;
            _playerModelFactory = playerModelFactory;
            _playerModelDatabase = playerModelDatabase;
            _playerViewDatabase = playerViewDatabase;
            _gameStartedBus = gameStartedBus;
            _playerStatChangedBus = playerStatChangedBus;
            _playerViewFactory = playerViewFactory;
        }

        public void Initialize()
        {
            _monoBehaviourServiceLocator.UiObjects.PlayWithBuffsButton.onClick.AddListener(PlayWithBuffs);
            _monoBehaviourServiceLocator.UiObjects.PlayWithoutBuffsButton.onClick.AddListener(PlayWithoutBuffs);

            var ids = new[]
            {
                0, 1
            };

            BuildModels(ids);
        }

        private void PlayWithBuffs()
        {
            _gameStartedBus.Fire(new GameStartedSignal(true));
        }

        private void PlayWithoutBuffs()
        {
            _gameStartedBus.Fire(new GameStartedSignal(false));
        }

        private void BuildModels(int[] ids)
        {
            foreach (var id in ids)
            {
                var playerView = _playerViewFactory.Create(id);
                var playerModel = _playerModelFactory.Create(id);
                var playerRichModelDecorator = new PlayerRichModelDecorator(playerModel, _playerStatChangedBus);

                _playerModelDatabase.Add(id, playerRichModelDecorator);
                _playerViewDatabase.Add(id, playerView);
                _bus.Fire(new PlayerAddedSignal(id));
            }
        }
    }
}