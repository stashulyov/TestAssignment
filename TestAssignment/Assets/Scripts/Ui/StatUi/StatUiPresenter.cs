using System.Globalization;
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

        public void SetValue(float value)
        {
            _view.SetText(value.ToString(CultureInfo.CurrentCulture));
        }

        public void SetTitle(string title)
        {
            _view.SetText(title);
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