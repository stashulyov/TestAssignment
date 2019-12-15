using Ui;

namespace GameData
{
    public class StatUi
    {
        public readonly EStatType Type;
        public readonly string Title;
        public readonly Icon Icon;

        public StatUi(EStatType type, string title, Icon icon)
        {
            Type = type;
            Title = title;
            Icon = icon;
        }
    }
}