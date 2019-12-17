using ScriptableObjects;
using Ui;

namespace Buffs
{
    public class BuffUi
    {
        public readonly string Title;
        public readonly Icon Icon;

        public BuffUi(string title, Icon icon)
        {
            Title = title;
            Icon = icon;
        }
    }
}