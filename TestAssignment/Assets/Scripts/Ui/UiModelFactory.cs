namespace Common
{
    public class UiModelFactory : IUiModelFactory
    {
        public IUiModel Create(int playerId)
        {
            return new UiModel(playerId);
        }
    }
}