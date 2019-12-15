using UnityEngine;

namespace Proxies
{
    public class ResourcesProxy : IResources
    {
        public T Load<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }
    }
}