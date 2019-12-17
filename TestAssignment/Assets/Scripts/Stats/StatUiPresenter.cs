using System;
using System.Globalization;
using ScriptableObjects;
using Ui;
using UnityEngine;

namespace Stats
{
    public class StatUiPresenter
    {
        private readonly StatUiView _view;
        private readonly Action<StatUiPresenter> _onDespawn;

        public StatUiPresenter(StatUiView view, Action<StatUiPresenter> onDespawn)
        {
            _view = view;
            _onDespawn = onDespawn;
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
        
        public void Despawn()
        {
            _onDespawn.Invoke(this);
        }

        public void SetActive(bool state)
        {
            _view.SetActive(state);
        }
    }
}