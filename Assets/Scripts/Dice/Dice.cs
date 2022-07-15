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
    public Sprite sprite;
    public T value;

    public DiceOption(string name, Sprite sprite, T value)
    {
        this.name = name;
        this.sprite = sprite;
        this.value = value;
    }
}