using System.Linq;
using Core;
using GameData;
using Stats;
using UnityEngine;

namespace Buffs
{
    public class BuffDatabase : ADatabase<EBuffType, Buff>, IBuffDatabase
    {
        public BuffDatabase(GameDataProvider gameDataProvider)
        {
            foreach (var data in gameDataProvider.Data.buffs)
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

        public Buff GetRandomBuff()
        {
            var random = Random.Range(0, Count);
            return All.ElementAt(random).Value;
        }
    }
}