using System;
using GameData;

namespace Players
{
    public interface IPlayerModel
    {
        event Action<EStatType, float> OnChange;
        
        float Hp { get; set; }
        float Armor { get; set; }
        float Vampirism { get; set; }
        float Damage { get; set; }

        void Attack(float damage);
    }
}