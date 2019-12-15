using Ui.StatUi;

namespace Common
{
    public class UiModel : IUiModel
    {
        public int Id { get; }

        public UiModel(int id)
        {
            Id = id;
        }

        public void AddPresenter(StatUiPresenter presenter)
        {
        }
    }
}