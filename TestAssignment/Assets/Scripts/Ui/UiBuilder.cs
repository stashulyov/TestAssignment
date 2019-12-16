using GameData;
using Signals;
using Ui.StatUi;
using Ui.UiModel;

namespace Common
{
    public class UiBuilder : IPlayerAddedListener
    {
        private readonly IUiModelFactory _uiModelFactory;
        private readonly IUiModelDatabase _uiModelDatabase;
        private readonly IStatUiDatabase _statUiDatabase;
        private readonly IPlayerSceneProvider _playerSceneProvider;
        private readonly IStatUiPool _statUiPool;
        private readonly IUiModelBuiltBus _bus;

        public UiBuilder(IUiModelFactory uiModelFactory, IUiModelDatabase uiModelDatabase, IStatUiDatabase statUiDatabase,
            IStatUiPool statUiPool, IPlayerSceneProvider playerSceneProvider, IUiModelBuiltBus bus)
        {
            _uiModelFactory = uiModelFactory;
            _uiModelDatabase = uiModelDatabase;
            _statUiDatabase = statUiDatabase;
            _playerSceneProvider = playerSceneProvider;
            _statUiPool = statUiPool;
            _bus = bus;
        }

        public void OnPlayerAdded(PlayerAddedSignal signal)
        {
            var attackButton = _playerSceneProvider.GetButton(signal.PlayerId);
            var parent = _playerSceneProvider.GetTransform(signal.PlayerId);

            var uiModel = _uiModelFactory.Create(signal.PlayerId);
            uiModel.AddButton(attackButton);

            foreach (var item in _statUiDatabase.All)
            {
                var statUi = item.Value;
                var statUiPresenter = _statUiPool.Spawn();

                statUiPresenter.SetIcon(statUi.Icon);
                statUiPresenter.SetValue(0f);
                statUiPresenter.Attach(parent);

                uiModel.AddStatPresenter(statUi.Type, statUiPresenter);
            }

            _uiModelDatabase.Add(signal.PlayerId, uiModel);
            _bus.Fire(new UiModelBuiltSignal(signal.PlayerId));
        }
    }
}