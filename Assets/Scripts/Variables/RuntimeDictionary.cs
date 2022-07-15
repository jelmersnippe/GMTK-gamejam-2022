using System.Collections.Generic;
using UnityEngine;

public abstract class RuntimeDictionary<T> : ScriptableObject
{
    public Dictionary<T, int> items = new Dictionary<T, int>();

    public virtual void Add(T key)
    {
        if (items.ContainsKey(key))
        {
            items[key]++;
            Debug.Log("Incrementing value for " + key + " to " + items[key] + " in " + name);
        }
        else
        {
            Debug.Log("Adding key " + key + " to " + name);
            items[key] = 1;
        }
    }

    public virtual void Remove(T key)
    {
        if (items.ContainsKey(key))
        {
            Debug.Log("Removing key " + key + " from " + name);
            items.Remove(key);
        }
    }

    public void Clear()
    {
        items.Clear();
    }
}
