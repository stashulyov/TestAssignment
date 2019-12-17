namespace Proxies
{
    public interface IJson
    {
        T Deserialize<T>(string json);
        string Serialize(object obj);
    }
}