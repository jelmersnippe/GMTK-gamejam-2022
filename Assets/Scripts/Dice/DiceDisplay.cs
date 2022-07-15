using UnityEngine;

// TODO: Remove unnecessary wrapper class
public class DiceDisplay<T> : MonoBehaviour
{
    public Dice<T> dice;

    public DiceOption<T> Roll()
    {
        return dice.Roll();
    }
}
