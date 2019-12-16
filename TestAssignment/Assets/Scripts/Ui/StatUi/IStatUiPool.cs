namespace Ui.StatUi
{
    public interface IStatUiPool
    {
        StatUiPresenter Spawn();
        void Despawn(StatUiPresenter statUi);
    }
}