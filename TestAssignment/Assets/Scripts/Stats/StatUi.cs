using ScriptableObjects;
using Ui;

namespace Stats
{
    public class StatUi
    {
        public readonly EStatType Type;
        public readonly Icon Icon;

        public StatUi(EStatType type, Icon icon)
        {
            Type = type;
            Icon = icon;
        }
    }
}