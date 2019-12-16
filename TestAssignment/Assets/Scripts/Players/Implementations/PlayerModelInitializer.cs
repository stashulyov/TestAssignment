using System;
using GameData;
using Players;

namespace Buffs
{
    public class PlayerModelInitializer : IPlayerModelInitializer
    {
        private readonly IStatDatabase _statDatabase;

        public PlayerModelInitializer(IStatDatabase statDatabase)
        {
            _statDatabase = statDatabase;
        }

        public void InitializeModel(IPlayerModel playerModel)
        {
            foreach (var item in _statDatabase.All)
            {
                var stat = item.Value;

                switch (stat.Type)
                {
                    case EStatType.Hp:
                        playerModel.Hp = stat.Value;
                        break;

                    case EStatType.Armor:
                        playerModel.Armor = stat.Value;
                        break;

                    case EStatType.Damage:
                        playerModel.Damage = stat.Value;
                        break;

                    case EStatType.Vampirism:
                        playerModel.Vampirism = stat.Value;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}