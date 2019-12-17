using UnityEngine.UI;

namespace Ui
{
    public class StartButtonsProvider : IStartButtonsProvider
    {
        public Button StartWithBuffsButton => _uiObjects.PlayWithBuffsButton;
        public Button StartWithoutBuffsButton => _uiObjects.PlayWithoutBuffsButton;

        private readonly UiObjects _uiObjects;

        public StartButtonsProvider(UiObjects uiObjects)
        {
            _uiObjects = uiObjects;
        }
    }
}