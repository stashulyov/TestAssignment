using Ui;

namespace Stats
{
    public interface IStatUiPool
    {
        StatUiPresenter Spawn();
        void Despawn(StatUiPresenter statUi);
    }
}