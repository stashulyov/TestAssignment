using Core;
using Players;
using Ui;

namespace Game
{
    public class GameDirector : IInitializable
    {
        private readonly IStartButtonsProvider _startButtonsProvider;
        private readonly IPlayerIdsProvider _playerIdsProvider;
        private readonly IGameStartedBus _gameStartedBus;
        private readonly IPlayerBuilder _playerBuilder;

        public GameDirector(IStartButtonsProvider startButtonsProvider, IPlayerIdsProvider playerIdsProvider, IGameStartedBus gameStartedBus,
            IPlayerBuilder playerBuilder)
        {
            _startButtonsProvider = startButtonsProvider;
            _playerIdsProvider = playerIdsProvider;
            _gameStartedBus = gameStartedBus;
            _playerBuilder = playerBuilder;
        }

        public void Initialize()
        {
            _startButtonsProvider.StartWithBuffsButton.onClick.AddListener(() => Play(true));
            _startButtonsProvider.StartWithoutBuffsButton.onClick.AddListener(() => Play(false));

            foreach (var id in _playerIdsProvider.GetPlayerIds())
                _playerBuilder.Build(id);

            Play(false);
        }

        private void Play(bool buffsAreEnabled)
        {
            _gameStartedBus.Fire(new GameStartedSignal(buffsAreEnabled));
        }
    }
}