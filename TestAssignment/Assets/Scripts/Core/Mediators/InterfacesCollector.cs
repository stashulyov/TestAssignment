using System.Collections.Generic;
using System.Reflection;

namespace Core
{
    public class InterfacesCollector
    {
        private const BindingFlags BindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        private readonly object _instance;
        private readonly FieldInfo[] _fields;

        public InterfacesCollector(object instance)
        {
            _instance = instance;
            _fields = instance.GetType().GetFields(BindingAttr);
        }

        public List<T> GetListTypes<T>() where T : class
        {
            return GetListTypes<T>(_fields, _instance);
        }

        private List<T> GetListTypes<T>(FieldInfo[] fields, object instance) where T : class
        {
            var listTypes = new List<T>();
            if (fields == null || fields.Length == 0)
                return listTypes;

            foreach (var item in fields)
            {
                if (item.GetValue(instance) is T type)
                    listTypes.Add(type);
            }

            return listTypes;
        }
    }
}