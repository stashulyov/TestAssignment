using LitJson;
using UnityEngine;

namespace Proxies
{
    public interface IJson
    {
        T Deserialize<T>(string json);
        string Serialize(object obj);
    }

    public interface IResources
    {
        T Load<T>(string path) where T : Object;
    }

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

    public class ResourcesProxy : IResources
    {
        public T Load<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }
    }
}