using Prefabs;
using UnityEngine;

namespace Ui.StatUi
{
    public class StatUiFactory : IStatUiFactory
    {
        private const string PrefabName = "Stat";

        private readonly IPrefabsDatabase _prefabsDatabase;

        public StatUiFactory(IPrefabsDatabase prefabsDatabase)
        {
            _prefabsDatabase = prefabsDatabase;
        }

        public StatUiPresenter Create()
        {
            var prefab = _prefabsDatabase.Get(PrefabName);
            var gameObject = Object.Instantiate(prefab);

            var view = gameObject.GetComponent<StatUiView>();
            var presenter = new StatUiPresenter(view);

            return presenter;
        }
    }
}