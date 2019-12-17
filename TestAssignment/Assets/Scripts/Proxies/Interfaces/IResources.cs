using UnityEngine;

namespace Proxies
{
    public interface IResources
    {
        T Load<T>(string path) where T : Object;
    }
}