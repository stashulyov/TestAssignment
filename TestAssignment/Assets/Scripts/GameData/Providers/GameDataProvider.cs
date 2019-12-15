using Proxies;
using UnityEngine;

namespace GameData
{
    public class GameDataProvider : IGameDataProvider
    {
        private const string DataPath = "data";

        private GameData _data;
        public GameData Data => _data ?? (_data = GetData());

        private readonly IResources _resources;
        private readonly IJson _json;

        public GameDataProvider(IResources resources, IJson json)
        {
            _resources = resources;
            _json = json;
        }

        private GameData GetData()
        {
            var textAsset = _resources.Load<TextAsset>(DataPath);
            return _json.Deserialize<GameData>(textAsset.text);
        }
    }
}