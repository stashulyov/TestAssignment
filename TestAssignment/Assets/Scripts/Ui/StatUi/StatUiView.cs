using UnityEngine;
using UnityEngine.UI;

namespace Ui.StatUi
{
    public class StatUiView : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private Image _icon;

        public void SetText(string text)
        {
            _text.text = text;
        }

        public void SetIcon(Sprite sprite)
        {
            _icon.sprite = sprite;
        }

        public void Attach(Transform parent)
        {
            transform.SetParent(parent);
            transform.localScale = Vector3.one;
            transform.localPosition = Vector3.zero;
        }
    }
}