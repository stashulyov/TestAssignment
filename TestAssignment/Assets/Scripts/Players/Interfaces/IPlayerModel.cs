using System;
using System.Collections.Generic;
using GameData;

namespace Players
{
    public interface IPlayerModel
    {
        event Action<int, EStatType, float> OnChangeStat;
        event Action<int, List<Buff>> OnChangeBuffs;

        float Hp { get; set; }
        float Armor { get; set; }
        float Vampirism { get; set; }
        float Damage { get; set; }

        void ApplyDamage(float damage);
        void ApplyBuffs(List<Buff> buffs);
    }
}