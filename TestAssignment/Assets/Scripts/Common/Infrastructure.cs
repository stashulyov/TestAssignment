using GameData;
using Players;
using Prefabs;
using Proxies;
using ScriptableObjects;
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

        private PlayerModelFactory _playerModelFactory;
        private PlayerModelDatabase _playerModelDatabase;
        private PlayerModelBuilder _playerModelBuilder;

        private PlayerViewFactory _playerViewFactory;
        private PlayerViewDatabase _playerViewDatabase;
        private IPlayerViewBuilder _playerViewBuilder;

        private UiModelFactory _uiModelFactory;
        private UiModelDatabase _uiModelDatabase;
        private UiBuilder _uiBuilder;

        private GameDirector _gameDirector;

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

            _playerModelFactory = new PlayerModelFactory();
            _playerModelDatabase = new PlayerModelDatabase();
            _playerModelBuilder = new PlayerModelBuilder(_playerModelFactory, _playerModelDatabase);

            _playerViewFactory = new PlayerViewFactory();
            _playerViewDatabase = new PlayerViewDatabase();
            _playerViewBuilder = new PlayerViewBuilder(_playerViewFactory, _playerViewDatabase);

            _uiModelFactory = new UiModelFactory();
            _uiModelDatabase = new UiModelDatabase();
            _uiBuilder = new UiBuilder(_uiModelFactory, _uiModelDatabase, _statUiDatabase, _statUiFactory);

            _gameDirector = new GameDirector(_playerModelBuilder, _playerViewBuilder, _uiBuilder, _monoBehaviourServiceLocator);
        }
    }
}