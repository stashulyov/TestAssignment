using System;
using GameData;

namespace Players
{
    public class PlayerModelInitializer : IPlayerModelInitializer
    {
        private readonly IStatDatabase _statDatabase;
        private readonly IPlayerModelDatabase _playerModelDatabase;

        public PlayerModelInitializer(IStatDatabase statDatabase, IPlayerModelDatabase playerModelDatabase)
        {
            _statDatabase = statDatabase;
            _playerModelDatabase = playerModelDatabase;
        }

        public void InitializeModel(int playerId)
        {
            var playerModel = _playerModelDatabase.Get(playerId);

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