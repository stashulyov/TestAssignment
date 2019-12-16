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
            if (_buffDatabase.Count <= buffs.Capacity)
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