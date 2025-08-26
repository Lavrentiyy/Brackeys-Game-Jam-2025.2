using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator
{
    private Dictionary<string, object> servicesDict = new Dictionary<string, object>();

    public void Add(object ob)
    {
        var id = ob.GetType().Name;
        if (servicesDict.ContainsKey(id))
        {
            Debug.LogError($"Trying add {id} already exist in services");
            return;
        }
        
        servicesDict.Add(id, ob);
    }

    public T Get<T>()
    {
        var getId = typeof(T).Name;
        
        if (servicesDict.TryGetValue(getId, out var value))
            return (T)value;
        
        return default;
    }
}
