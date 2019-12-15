using LitJson;

namespace Proxies
{
    public class JsonProxy : IJson
    {
        public string Serialize(object obj)
        {
            return JsonMapper.ToJson(obj);
        }

        public T Deserialize<T>(string json)
        {
            return JsonMapper.ToObject<T>(json);
        }
    }
}