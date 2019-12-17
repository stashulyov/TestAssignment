using Core;

namespace GameData
{
    public class StatDatabase : ADatabase<EStatType, Stat>, IStatDatabase
    {
        public StatDatabase(IGameDataProvider gameDataProvider)
        {
            foreach (var data in gameDataProvider.Data.stats)
            {
                var type = (EStatType) data.id;
                var stat = new Stat(type, data.value);

                Add(stat.Type, stat);
            }
        }
    }
}