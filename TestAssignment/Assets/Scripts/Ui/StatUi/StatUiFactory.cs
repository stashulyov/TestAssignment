using System;
using Prefabs;
using Object = UnityEngine.Object;

namespace Ui
{
    public class StatUiFactory : IStatUiFactory
    {
        private const string PrefabName = "Stat";

        private readonly IPrefabsDatabase _prefabsDatabase;

        public StatUiFactory(IPrefabsDatabase prefabsDatabase)
        {
            _prefabsDatabase = prefabsDatabase;
        }

        public StatUiPresenter Create(Action<StatUiPresenter> despawnCallback)
        {
            var prefab = _prefabsDatabase.Get(PrefabName);
            var gameObject = Object.Instantiate(prefab);

            var view = gameObject.GetComponent<StatUiView>();
            var presenter = new StatUiPresenter(view, despawnCallback);

            return presenter;
        }
    }
}