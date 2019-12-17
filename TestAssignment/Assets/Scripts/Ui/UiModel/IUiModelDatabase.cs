namespace Ui
{
    public interface IUiModelDatabase
    {
        void Add(int id, IUiModel uiModel);
        IUiModel Get(int playerId);
    }
}