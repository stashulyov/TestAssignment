namespace Common
{
    public interface IUiModelFactory
    {
        IUiModel Create(int playerId);
    }
}