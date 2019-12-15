using GameData;
using UnityEngine;

namespace Ui.StatUi
{
    public class PlayerUiBuilder
    {
        private readonly IStatUiFactory _factory;
        private readonly IStatUiDatabase _statDatabase;

        public PlayerUiBuilder(IStatUiFactory factory, IStatUiDatabase statDatabase)
        {
            _factory = factory;
            _statDatabase = statDatabase;
        }

        public void Build(Transform[] parents)
        {
            foreach (var parent in parents)
            {
                foreach (var item in _statDatabase.All)
                {
                    var statUi = item.Value;

                    var statUiPresenter = _factory.Create();

                    statUiPresenter.SetIcon(statUi.Icon);
                    statUiPresenter.SetText(statUi.Title);

                    statUiPresenter.Attach(parent);
                }
            }
        }
    }
}