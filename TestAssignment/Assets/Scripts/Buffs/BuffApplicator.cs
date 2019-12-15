using System;
using GameData;
using Players;

namespace Buffs
{
    public class BuffApplicator : IBuffApplicator
    {
        public void Apply(IPlayerModel model, Buff buff)
        {
            foreach (var stat in buff.Stats)
            {
                switch (stat.Type)
                {
                    case EStatType.Hp:
                        model.SetHp(model.Hp + stat.Value);
                        break;

                    case EStatType.Armor:
                        model.SetArmor(model.Armor + stat.Value);
                        break;

                    case EStatType.Damage:
                        model.SetDamage(model.Damage + stat.Value);
                        break;

                    case EStatType.Vampirism:
                        model.SetVampirism(model.Vampirism + stat.Value);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}