namespace Ui
{
    public interface IStatUiPool
    {
        StatUiPresenter Spawn();
        void Despawn(StatUiPresenter statUi);
    }
}