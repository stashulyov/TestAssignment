using UnityEngine;

namespace Ui.StatUi
{
    public class StatUiPresenter
    {
        private readonly StatUiView _view;

        public StatUiPresenter(StatUiView view)
        {
            _view = view;
        }

        public void SetText(string text)
        {
            _view.SetText(text);
        }

        public void SetIcon(Icon icon)
        {
            _view.SetIcon(icon.Sprite);
        }

        public void Attach(Transform parent)
        {
            _view.Attach(parent);
        }
    }
}