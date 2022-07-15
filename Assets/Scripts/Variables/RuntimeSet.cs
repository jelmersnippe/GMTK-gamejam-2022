using System.Collections.Generic;
using UnityEngine;

public abstract class RuntimeSet<T> : ScriptableObject
{
    public List<T> items = new List<T>();

    public void Add(T item)
    {
        if (!items.Contains(item))
        {
            Debug.Log("Adding item " + item + " to " + name);
            items.Add(item);
        }
    }

    public void Remove(T item)
    {
        if (items.Contains(item))
        {
            Debug.Log("Removing item " + item + " from " + name);
            items.Remove(item);
        }
    }

    public void Clean()
    {
        items = new List<T>();
    }
}
