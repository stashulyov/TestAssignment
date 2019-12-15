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
            _view.SetValue(value.ToString(CultureInfo.CurrentCulture));
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