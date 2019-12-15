using Ui;

namespace GameData
{
    public class BuffUi
    {
        public readonly EBuffType Type;
        public readonly string Title;
        public readonly Icon Icon;

        public BuffUi(EBuffType type, string title, Icon icon)
        {
            Type = type;
            Title = title;
            Icon = icon;
        }
    }
}