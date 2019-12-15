using Ui.StatUi;

namespace Common
{
    public interface IUiModel
    {
        int Id { get; }

        void AddPresenter(StatUiPresenter presenter);
    }
}