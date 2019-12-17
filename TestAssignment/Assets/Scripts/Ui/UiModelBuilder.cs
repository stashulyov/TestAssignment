using GameData;
using Players;
using Stats;

namespace Ui
{
    public class UiModelBuilder : IPlayerAddedListener
    {
        private readonly IUiModelFactory _uiModelFactory;
        private readonly IUiModelDatabase _uiModelDatabase;
        private readonly IStatUiDatabase _statUiDatabase;
        private readonly IStatUiPool _statUiPool;
        private readonly IAttackButtonProvider _attackButtonProvider;
        private readonly ITransformProvider _transformProvider;
        private readonly IUiModelBuiltBus _bus;

        public UiModelBuilder(IUiModelFactory uiModelFactory, IUiModelDatabase uiModelDatabase, IStatUiDatabase statUiDatabase,
            IStatUiPool statUiPool, IAttackButtonProvider attackButtonProvider, ITransformProvider transformProvider, IUiModelBuiltBus bus)
        {
            _uiModelFactory = uiModelFactory;
            _uiModelDatabase = uiModelDatabase;
            _statUiDatabase = statUiDatabase;
            _statUiPool = statUiPool;
            _attackButtonProvider = attackButtonProvider;
            _transformProvider = transformProvider;
            _bus = bus;
        }

        public void OnPlayerAdded(PlayerAddedSignal signal)
        {
            var attackButton = _attackButtonProvider.GetAttackButton(signal.PlayerId);
            var parent = _transformProvider.GetTransform(signal.PlayerId);

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