using Common;
using ScriptableObjects;

namespace GameData
{
    public class StatUiDatabase : ADatabase<EStatType, StatUi>, IStatUiDatabase
    {
        public StatUiDatabase(IGameDataProvider gameDataProvider, IIconsDatabase iconsDatabase)
        {
            foreach (var data in gameDataProvider.Data.stats)
            {
                var type = (EStatType) data.id;
                var icon = iconsDatabase.Get(data.icon);
                var stat = new StatUi(type, data.title, icon);

                Add(stat.Type, stat);
            }
        }
    }
}