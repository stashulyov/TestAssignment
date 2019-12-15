using Common;

namespace GameData
{
    public class BuffDatabase : ADatabase<EBuffType, Buff>, IBuffDatabase
    {
        public BuffDatabase(BuffData[] buffData)
        {
            foreach (var data in buffData)
            {
                var type = (EBuffType) data.id;
                var buffStats = ParseBuffStats(data.stats);
                var buff = new Buff(type, buffStats);

                Add(buff.Type, buff);
            }
        }

        private BuffStat[] ParseBuffStats(BuffStatData[] dataArray)
        {
            var array = new BuffStat[dataArray.Length];

            for (int i = 0; i < dataArray.Length; i++)
            {
                var statData = dataArray[i];
                var type = (EStatType) statData.statId;
                var buffStat = new BuffStat(type, statData.value);

                array[i] = buffStat;
            }

            return array;
        }
    }
}