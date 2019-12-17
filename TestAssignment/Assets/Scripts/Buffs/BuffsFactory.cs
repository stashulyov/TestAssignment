using System.Collections.Generic;
using Game;
using UnityEngine;

namespace Buffs
{
    public class BuffsFactory : IBuffsFactory
    {
        private readonly IGameSettings _gameSettings;
        private readonly IBuffDatabase _buffDatabase;

        public BuffsFactory(IGameSettings gameSettings, IBuffDatabase buffDatabase)
        {
            _gameSettings = gameSettings;
            _buffDatabase = buffDatabase;
        }

        public List<Buff> Create()
        {
            var buffsCount = Random.Range(_gameSettings.BuffCountMin, _gameSettings.BuffCountMax + 1);
            var buffs = new List<Buff>(buffsCount);

            for (int i = 0; i < buffs.Capacity; i++)
            {
                if (_gameSettings.AllowDuplicateBuffs)
                    buffs.Add(_buffDatabase.GetRandomBuff());
                else
                    buffs.Add(GetUniqueBuff(buffs));
            }

            return buffs;
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