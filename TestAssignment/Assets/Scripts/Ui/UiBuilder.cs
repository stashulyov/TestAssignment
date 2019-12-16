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
        private readonly IStatUiFactory _statUiFactory;
        private readonly IPlayerSceneProvider _playerSceneProvider;
        private readonly IUiModelBuiltBus _bus;

        public UiBuilder(IUiModelFactory uiModelFactory, IUiModelDatabase uiModelDatabase, IStatUiDatabase statUiDatabase,
            IStatUiFactory statUiFactory, IPlayerSceneProvider playerSceneProvider, IUiModelBuiltBus bus)
        {
            _uiModelFactory = uiModelFactory;
            _uiModelDatabase = uiModelDatabase;
            _statUiDatabase = statUiDatabase;
            _statUiFactory = statUiFactory;
            _playerSceneProvider = playerSceneProvider;
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
                var statUiPresenter = _statUiFactory.Create();

                statUiPresenter.SetIcon(statUi.Icon);
                statUiPresenter.SetValue(0f);
                statUiPresenter.Attach(parent);

                uiModel.AddPresenter(statUi.Type, statUiPresenter);
            }

            _uiModelDatabase.Add(signal.PlayerId, uiModel);
            _bus.Fire(new UiModelBuiltSignal(signal.PlayerId));
        }
    }
}