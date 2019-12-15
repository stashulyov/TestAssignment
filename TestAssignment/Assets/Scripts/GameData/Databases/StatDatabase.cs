using Common;

namespace GameData
{
    public class StatDatabase : ADatabase<EStatType, Stat>, IStatDatabase
    {
        public StatDatabase(StatData[] statData)
        {
            foreach (var data in statData)
            {
                var type = (EStatType) data.id;
                var stat = new Stat(type, data.value);

                Add(stat.Type, stat);
            }
        }
    }
}