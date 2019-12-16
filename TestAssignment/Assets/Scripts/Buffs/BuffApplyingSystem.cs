using System.Collections.Generic;
using GameData;
using Players;
using UnityEngine;

namespace Buffs
{
    public class BuffApplyingSystem : IBuffApplyingSystem
    {
        private readonly IGameSettings _gameSettings;
        private readonly IBuffDatabase _buffDatabase;

        public BuffApplyingSystem(IGameSettings gameSettings, IBuffDatabase buffDatabase)
        {
            _gameSettings = gameSettings;
            _buffDatabase = buffDatabase;
        }

        public void ApplyBuffs(IPlayerModel playerModel)
        {
            // todo generates non-unique buffs
            
            var buffsCount = Random.Range(_gameSettings.BuffCountMin, _gameSettings.BuffCountMax + 1);
            var buffs = new List<Buff>(buffsCount);

            for (int i = 0; i < buffs.Capacity; i++)
            {
                if (_gameSettings.AllowDuplicateBuffs)
                    buffs.Add(_buffDatabase.GetRandomBuff());
                else
                    buffs.Add(GetUniqueBuff(buffs));
            }

            playerModel.ApplyBuffs(buffs);
        }

        private Buff GetUniqueBuff(List<Buff> buffs)
        {
            // в data описано 4 баффа, а BuffCountMax = 5, то есть если стоит условие AllowDuplicateBuffs = false,
            // и нужно получить уникальные баффы, система уйдёт в бесконечный поиск на последнем
            
            if (_buffDatabase.Count <= buffs.Count)
                return _buffDatabase.GetRandomBuff();

            Buff buff;
            do
            {
                buff = _buffDatabase.GetRandomBuff();
            } while (buffs.Contains(buff));

            return buff;
        }
    }
}