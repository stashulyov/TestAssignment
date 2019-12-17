using GameData;
using Stats;

namespace Players
{
    public class PlayerRichModelDecorator : IPlayerModel
    {
        private readonly IPlayerModel _playerModel;
        private readonly IPlayerStatChangedBus _playerStatChangedBus;

        public PlayerRichModelDecorator(IPlayerModel playerModel, IPlayerStatChangedBus playerStatChangedBus)
        {
            _playerModel = playerModel;
            _playerStatChangedBus = playerStatChangedBus;
        }

        public int PlayerId => _playerModel.PlayerId;
        public bool IsDead => _playerModel.IsDead;

        public float Hp
        {
            get => _playerModel.Hp;
            set
            {
                var checkedValue = GetCheckedValue(value);
                _playerModel.Hp = checkedValue;
                InvokeOnChangeStat(EStatType.Hp, checkedValue);
            }
        }

        public float Armor
        {
            get => _playerModel.Armor;
            set
            {
                var checkedValue = GetCheckedValue(value);
                _playerModel.Armor = checkedValue;
                InvokeOnChangeStat(EStatType.Armor, checkedValue);
            }
        }

        public float Vampirism
        {
            get => _playerModel.Vampirism;
            set
            {
                var checkedValue = GetCheckedValue(value);
                _playerModel.Vampirism = checkedValue;
                InvokeOnChangeStat(EStatType.Vampirism, checkedValue);
            }
        }

        public float Damage
        {
            get => _playerModel.Damage;
            set
            {
                var checkedValue = GetCheckedValue(value);
                _playerModel.Damage = checkedValue;
                InvokeOnChangeStat(EStatType.Damage, checkedValue);
            }
        }

        private float GetCheckedValue(float value)
        {
            if (value < 0f)
                return 0f;

            return value;
        }

        private void InvokeOnChangeStat(EStatType type, float value)
        {
            var signal = new PlayerStatChangedSignal(PlayerId, new Stat(type, value));
            _playerStatChangedBus.Fire(signal);
        }
    }
}