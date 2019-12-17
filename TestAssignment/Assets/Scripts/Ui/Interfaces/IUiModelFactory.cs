namespace Ui
{
    public interface IUiModelFactory
    {
        IUiModel Create(int playerId);
    }
}