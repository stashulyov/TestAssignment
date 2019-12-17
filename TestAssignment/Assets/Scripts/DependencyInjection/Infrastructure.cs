using System.Collections.Generic;
using Buffs;
using GameData;
using Players;
using Prefabs;
using Proxies;
using ScriptableObjects;
using Signals;
using Ui.StatUi;

namespace Common
{
    public class Infrastructure
    {
        private readonly MonoBehaviourServiceLocator _monoBehaviourServiceLocator;

        private PrefabsDatabase _prefabsDatabase;
        private IconsDatabase _iconsDatabase;

        private ResourcesProxy _resourcesProxy;
        private JsonProxy _jsonProxy;

        private GameDataProvider _gameDataProvider;

        private StatUiFactory _statUiFactory;
        private StatUiDatabase _statUiDatabase;
        private StatUiPool _statUiPool;

        private PlayerModelFactory _playerModelFactory;
        private PlayerModelDatabase _playerModelDatabase;

        private PlayerViewDatabase _playerViewDatabase;

        private PlayerSceneUiProvider _playerSceneUiProvider;

        private UiModelFactory _uiModelFactory;
        private UiModelDatabase _uiModelDatabase;
        private UiBuilder _uiBuilder;

        private BuffUiDatabase _buffUiDatabase;

        private DamageApplicator _damageApplicator;

        private AttackUiModelSystem _attackUiModelSystem;

        private GameDirector _gameDirector;
        private GameController _gameController;

        private PlayerModelInitializer _playerModelInitializer;
        private BuffApplyingSystem _buffApplyingSystem;

        private StatDatabase _statDatabase;

        private UiModelBuffsUpdateSystem _uiModelBuffsUpdateSystem;

        private GameSettings _gameSettings;
        private BuffDatabase _buffDatabase;

        private PlayerAddedBus _playerAddedBus;
        private UiModelBuiltBus _uiModelBuiltBus;
        private GameStartedBus _gameStartedBus;

        private PlayerBuffsBus _playerBuffsBus;
        private PlayerStatChangedBus _playerStatChangedBus;
        private BuffsFactory _buffsFactory;
        private PlayerViewFactory _playerViewFactory;
        private UiModelStatUpdateSystem _uiModelStatUpdateSystem;

        public Infrastructure(MonoBehaviourServiceLocator monoBehaviourServiceLocator)
        {
            _monoBehaviourServiceLocator = monoBehaviourServiceLocator;
        }

        public void BuildGraph()
        {
            _prefabsDatabase = new PrefabsDatabase(_monoBehaviourServiceLocator.PrefabsDatabaseAsset);
            _iconsDatabase = new IconsDatabase(_monoBehaviourServiceLocator.IconsDatabaseAsset);

            _resourcesProxy = new ResourcesProxy();
            _jsonProxy = new JsonProxy();

            _gameDataProvider = new GameDataProvider(_resourcesProxy, _jsonProxy);

            _statUiFactory = new StatUiFactory(_prefabsDatabase);
            _statUiDatabase = new StatUiDatabase(_gameDataProvider, _iconsDatabase);
            _statUiPool = new StatUiPool(_statUiFactory);

            _playerModelFactory = new PlayerModelFactory();
            _playerModelDatabase = new PlayerModelDatabase();

            _playerViewDatabase = new PlayerViewDatabase();

            _playerSceneUiProvider = new PlayerSceneUiProvider(_monoBehaviourServiceLocator.UiObjects.Hierarchies);

            _uiModelFactory = new UiModelFactory();
            _uiModelDatabase = new UiModelDatabase();

            _damageApplicator = new DamageApplicator(_playerModelDatabase);

            _buffUiDatabase = new BuffUiDatabase(_gameDataProvider, _iconsDatabase);

            _attackUiModelSystem = new AttackUiModelSystem(_uiModelDatabase, _playerViewDatabase, _damageApplicator);
            _uiModelBuffsUpdateSystem = new UiModelBuffsUpdateSystem(_uiModelDatabase, _buffUiDatabase, _statUiPool, _playerSceneUiProvider);
            _uiModelStatUpdateSystem = new UiModelStatUpdateSystem(_uiModelDatabase);

            _uiModelBuiltBus = new UiModelBuiltBus(new List<IUiModelBuiltListener>()
            {
                _attackUiModelSystem
            });

            _uiBuilder = new UiBuilder(_uiModelFactory, _uiModelDatabase, _statUiDatabase, _statUiPool, _playerSceneUiProvider, _uiModelBuiltBus);

            _playerAddedBus = new PlayerAddedBus(new List<IPlayerAddedListener>()
            {
                _uiBuilder
            });

            _statDatabase = new StatDatabase(_gameDataProvider);

            _gameSettings = new GameSettings(_gameDataProvider);

            _buffDatabase = new BuffDatabase(_gameDataProvider);

            _playerBuffsBus = new PlayerBuffsBus(new List<IPlayerBuffsAttachedListener>()
            {
                _uiModelBuffsUpdateSystem
            }, new List<IPlayerBuffsDetachedListener>()
            {
                _uiModelBuffsUpdateSystem,
            });

            _playerModelInitializer = new PlayerModelInitializer(_statDatabase);

            _buffsFactory = new BuffsFactory(_gameSettings, _buffDatabase);

            _buffApplyingSystem = new BuffApplyingSystem(_buffsFactory, _playerBuffsBus);

            _gameController = new GameController(_playerModelInitializer, _playerModelDatabase, _buffApplyingSystem);

            _gameStartedBus = new GameStartedBus(new List<IGameStartedListener>()
            {
                _gameController
            });

            _playerStatChangedBus = new PlayerStatChangedBus(new List<IPlayerStatChangedListener>()
            {
                _uiModelStatUpdateSystem
            });

            _playerViewFactory = new PlayerViewFactory(_monoBehaviourServiceLocator.UiObjects.Hierarchies);

            _gameDirector = new GameDirector(_monoBehaviourServiceLocator, _playerAddedBus, _playerModelFactory, _playerModelDatabase, _playerViewDatabase,
                _gameStartedBus, _playerStatChangedBus, _playerViewFactory);
        }
    }
}