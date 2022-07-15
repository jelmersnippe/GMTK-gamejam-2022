using UnityEngine;

public class DiceDisplay<T> : MonoBehaviour
{
    public Dice<T> dice;

    public DiceOption<T> Roll()
    {
        DiceOption<T> result = dice.Roll();

        Debug.Log("Rolled " + result.name + " with " + gameObject.name);

        return result;
    }
}
