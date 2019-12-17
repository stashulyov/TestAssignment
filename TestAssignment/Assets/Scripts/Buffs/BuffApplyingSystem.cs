using System;
using GameData;
using Players;
using Signals;

namespace Buffs
{
    public class BuffApplyingSystem : IBuffApplyingSystem
    {
        private readonly IBuffsFactory _buffsFactory;
        private readonly IPlayerBuffsBus _playerBuffsBus;

        public BuffApplyingSystem(IBuffsFactory buffsFactory, IPlayerBuffsBus playerBuffsBus)
        {
            _buffsFactory = buffsFactory;
            _playerBuffsBus = playerBuffsBus;
        }

        public void ApplyBuffs(IPlayerModel playerModel)
        {
            var buffs = _buffsFactory.Create();

            foreach (var buff in buffs)
            {
                foreach (var stat in buff.Stats)
                {
                    switch (stat.Type)
                    {
                        case EStatType.Hp:
                            playerModel.Hp += stat.Value;
                            break;

                        case EStatType.Armor:
                            playerModel.Armor += stat.Value;
                            break;

                        case EStatType.Damage:
                            playerModel.Damage += stat.Value;
                            break;

                        case EStatType.Vampirism:
                            playerModel.Vampirism += stat.Value;
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            _playerBuffsBus.Fire(new PlayerBuffsAttachedSignal(playerModel.PlayerId, buffs));
        }

        public void ClearBuffs(IPlayerModel playerModel)
        {
            _playerBuffsBus.Fire(new PlayerBuffsDetachedSignal(playerModel.PlayerId));
        }
    }
}