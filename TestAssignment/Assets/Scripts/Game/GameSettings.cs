using GameData;

namespace Game
{
    public class GameSettings : IGameSettings
    {
        public bool AllowDuplicateBuffs => _settings.allowDuplicateBuffs;
        public int BuffCountMin => _settings.buffCountMin;
        public int BuffCountMax => _settings.buffCountMax;

        private readonly GameModelData _settings;

        public GameSettings(IGameDataProvider gameDataProvider)
        {
            _settings = gameDataProvider.Data.settings;
        }
    }
}