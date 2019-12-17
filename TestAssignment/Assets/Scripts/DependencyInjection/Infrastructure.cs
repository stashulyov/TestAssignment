using System.Collections.Generic;
using Buffs;
using Damage;
using Game;
using GameData;
using Players;
using Prefabs;
using Proxies;
using Ui;

namespace DependencyInjection
{
    public class Infrastructure
    {
        private readonly MonoBehaviourServiceLocator _monoBehaviourServiceLocator;

        private PrefabsDatabase _prefabsDatabase;
        private IconsDatabase _iconsDatabase;

        private ResourcesProxy _resourcesProxy;
        private JsonProxy _jsonProxy;

        private GameDataProvider _gameDataProvider;
        private GameSettings _gameSettings;
        private PlayerSceneUiProvider _playerSceneUiProvider;
        private StartButtonsProvider _startButtonsProvider;

        private StatUiFactory _statUiFactory;
        private StatUiDatabase _statUiDatabase;
        private StatUiPool _statUiPool;
        private StatDatabase _statDatabase;

        private PlayerModelDatabase _playerModelDatabase;
        private PlayerViewDatabase _playerViewDatabase;
        private PlayerModelFactory _playerModelFactory;
        private PlayerModelInitializer _playerModelInitializer;
        private PlayerViewInitializer _playerViewInitializer;
        private PlayerViewFactory _playerViewFactory;

        private UiModelFactory _uiModelFactory;
        private UiModelDatabase _uiModelDatabase;

        private BuffUiDatabase _buffUiDatabase;
        private BuffDatabase _buffDatabase;
        private BuffsFactory _buffsFactory;
        private UiModelBuffsUpdateSystem _uiModelBuffsUpdateSystem;
        private UiModelStatUpdateSystem _uiModelStatUpdateSystem;

        private DamageApplicator _damageApplicator;
        private DamageCalculator _damageCalculator;
        private DamageSystem _damageSystem;
        private VampirismCalculator _vampirismCalculator;

        private PlayerAddedBus _playerAddedBus;
        private UiModelBuiltBus _uiModelBuiltBus;
        private GameStartedBus _gameStartedBus;
        private PlayerBuffsBus _playerBuffsBus;
        private PlayerStatChangedBus _playerStatChangedBus;

        private UiModelBuilder _uiModelBuilder;
        private BuffApplyingSystem _buffApplyingSystem;
        private GameController _gameController;
        private PlayerBuilder _playerBuilder;
        private GameDirector _gameDirector;

        public Infrastructure(MonoBehaviourServiceLocator monoBehaviourServiceLocator)
        {
            _monoBehaviourServiceLocator = monoBehaviourServiceLocator;
        }

        public void BuildGraph()
        {
            // SO
            _prefabsDatabase = new PrefabsDatabase(_monoBehaviourServiceLocator.PrefabsDatabaseAsset);
            _iconsDatabase = new IconsDatabase(_monoBehaviourServiceLocator.IconsDatabaseAsset);

            // Proxies
            _resourcesProxy = new ResourcesProxy();
            _jsonProxy = new JsonProxy();

            // Game
            _gameDataProvider = new GameDataProvider(_resourcesProxy, _jsonProxy);
            _gameSettings = new GameSettings(_gameDataProvider);
            _playerSceneUiProvider = new PlayerSceneUiProvider(_monoBehaviourServiceLocator.UiObjects.Hierarchies);
            _startButtonsProvider = new StartButtonsProvider(_monoBehaviourServiceLocator.UiObjects);

            // Stat
            _statDatabase = new StatDatabase(_gameDataProvider);
            _statUiFactory = new StatUiFactory(_prefabsDatabase);
            _statUiDatabase = new StatUiDatabase(_gameDataProvider, _iconsDatabase);
            _statUiPool = new StatUiPool(_statUiFactory);

            // Player
            _playerModelFactory = new PlayerModelFactory();
            _playerModelDatabase = new PlayerModelDatabase();
            _playerViewDatabase = new PlayerViewDatabase();
            _playerModelInitializer = new PlayerModelInitializer(_statDatabase, _playerModelDatabase);
            _playerViewInitializer = new PlayerViewInitializer(_playerViewDatabase);
            _playerViewFactory = new PlayerViewFactory(_monoBehaviourServiceLocator.UiObjects.Hierarchies);

            // Ui
            _uiModelFactory = new UiModelFactory();
            _uiModelDatabase = new UiModelDatabase();

            // Buffs
            _buffDatabase = new BuffDatabase(_gameDataProvider);
            _buffsFactory = new BuffsFactory(_gameSettings, _buffDatabase);
            _buffUiDatabase = new BuffUiDatabase(_gameDataProvider, _iconsDatabase);
            _uiModelBuffsUpdateSystem = new UiModelBuffsUpdateSystem(_uiModelDatabase, _buffUiDatabase, _statUiPool, _playerSceneUiProvider);
            _uiModelStatUpdateSystem = new UiModelStatUpdateSystem(_uiModelDatabase);

            // Damage
            _damageCalculator = new DamageCalculator();
            _vampirismCalculator = new VampirismCalculator();
            _damageApplicator = new DamageApplicator(_playerModelDatabase, _damageCalculator, _vampirismCalculator);
            _damageSystem = new DamageSystem(_uiModelDatabase, _playerViewDatabase, _damageApplicator, _playerModelDatabase);

            var uiModelBuiltListeners = new List<IUiModelBuiltListener> {_damageSystem};
            _uiModelBuiltBus = new UiModelBuiltBus(uiModelBuiltListeners);

            _uiModelBuilder = new UiModelBuilder(_uiModelFactory, _uiModelDatabase, _statUiDatabase, _statUiPool, _playerSceneUiProvider, 
                _playerSceneUiProvider, _uiModelBuiltBus);

            var playerBuffsAttachedListeners = new List<IPlayerBuffsAttachedListener> {_uiModelBuffsUpdateSystem};
            var playerBuffsDetachedListeners = new List<IPlayerBuffsDetachedListener> {_uiModelBuffsUpdateSystem};
            _playerBuffsBus = new PlayerBuffsBus(playerBuffsAttachedListeners, playerBuffsDetachedListeners);

            var playerStatChangedListeners = new List<IPlayerStatChangedListener> {_uiModelStatUpdateSystem};
            _playerStatChangedBus = new PlayerStatChangedBus(playerStatChangedListeners);

            var playerAddedListeners = new List<IPlayerAddedListener> {_uiModelBuilder};
            _playerAddedBus = new PlayerAddedBus(playerAddedListeners);

            _buffApplyingSystem = new BuffApplyingSystem(_buffsFactory, _playerBuffsBus, _playerModelDatabase);
            _gameController = new GameController(_playerModelInitializer, _playerViewInitializer, _playerModelDatabase, _buffApplyingSystem);

            var gameStartedListeners = new List<IGameStartedListener> {_gameController};
            _gameStartedBus = new GameStartedBus(gameStartedListeners);
            
            _playerBuilder = new PlayerBuilder(_playerModelFactory, _playerViewFactory,_playerStatChangedBus, _playerModelDatabase, _playerViewDatabase, 
                _playerAddedBus);

            _gameDirector = new GameDirector(_startButtonsProvider, _playerSceneUiProvider, _gameStartedBus, _playerBuilder);
        }
    }
}