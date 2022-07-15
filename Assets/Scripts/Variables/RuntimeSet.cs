using System.Collections.Generic;
using UnityEngine;

public abstract class RuntimeSet<T> : ScriptableObject
{
    public List<T> items = new List<T>();

    public void Add(T item)
    {
        if (!items.Contains(item))
        {
            Debug.Log("Adding item");
            items.Add(item);
        }
    }

    public void Remove(T item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
        }
    }

    public void Clean()
    {
        items = new List<T>();
    }
}
