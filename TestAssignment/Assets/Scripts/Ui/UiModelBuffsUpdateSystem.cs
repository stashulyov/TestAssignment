using Buffs;
using GameData;
using Players;
using Stats;

namespace Ui
{
    public class UiModelBuffsUpdateSystem : IPlayerBuffsAttachedListener, IPlayerBuffsDetachedListener
    {
        private readonly IUiModelDatabase _uiModelDatabase;
        private readonly IBuffUiDatabase _buffUiDatabase;
        private readonly IStatUiPool _statUiPool;
        private readonly ITransformProvider _transformProvider;

        public UiModelBuffsUpdateSystem(IUiModelDatabase uiModelDatabase, IBuffUiDatabase buffUiDatabase, IStatUiPool statUiPool,
            ITransformProvider transformProvider)
        {
            _uiModelDatabase = uiModelDatabase;
            _buffUiDatabase = buffUiDatabase;
            _statUiPool = statUiPool;
            _transformProvider = transformProvider;
        }

        public void OnBuffsAttached(PlayerBuffsAttachedSignal signal)
        {
            var uiModel = _uiModelDatabase.Get(signal.PlayerId);
            uiModel.ClearBuffs();

            foreach (var buff in signal.Buffs)
            {
                var buffUi = _buffUiDatabase.Get(buff.Type);
                var presenter = _statUiPool.Spawn();

                presenter.SetIcon(buffUi.Icon);
                presenter.SetTitle(buffUi.Title);

                var parent = _transformProvider.GetTransform(signal.PlayerId);
                presenter.Attach(parent);

                uiModel.AddBuffPresenter(presenter);
            }
        }

        public void OnBuffsDetached(PlayerBuffsDetachedSignal signal)
        {
            var uiModel = _uiModelDatabase.Get(signal.PlayerId);
            uiModel.ClearBuffs();
        }
    }
}