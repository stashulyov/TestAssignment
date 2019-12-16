using GameData;
using Players;

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
            var buff = _buffDatabase.GetRandomBuff();
            playerModel.ApplyBuff(buff);
        }
    }
}