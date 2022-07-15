using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dice<T>
{
    public DiceOption<T>[] options;

    public DiceOption<T> Roll()
    {
        int roll = Random.Range(0, options.Length);
        return options[roll];
    }
}

[System.Serializable]
public class DiceOption<T>
{

    public string name;
    public T value;

    public DiceOption(string name, T value)
    {
        this.name = name;
        this.value = value;
    }
}