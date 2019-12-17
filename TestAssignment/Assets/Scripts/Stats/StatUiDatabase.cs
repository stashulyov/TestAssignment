using Core;
using GameData;
using ScriptableObjects;
using Ui;

namespace Stats
{
    public class StatUiDatabase : ADatabase<EStatType, StatUi>, IStatUiDatabase
    {
        public StatUiDatabase(IGameDataProvider gameDataProvider, IIconsDatabase iconsDatabase)
        {
            foreach (var data in gameDataProvider.Data.stats)
            {
                var type = (EStatType) data.id;
                var icon = iconsDatabase.Get(data.icon);
                var stat = new StatUi(type, icon);

                Add(stat.Type, stat);
            }
        }
    }
}