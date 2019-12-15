using GameData;
using Prefabs;
using Proxies;
using ScriptableObjects;
using Ui.StatUi;
using UnityEngine;

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

        private PlayerUiBuilder _playerUiBuilder;

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

            _playerUiBuilder = new PlayerUiBuilder(_statUiFactory, _statUiDatabase);

            _playerUiBuilder.Build(new Transform[]
            {
                null, null
            });
        }
    }
}