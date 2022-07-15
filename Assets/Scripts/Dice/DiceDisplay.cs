using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DiceDisplay<T> : MonoBehaviour
{
    public Dice<T> dice;
    public SpriteRenderer displaySpriteRenderer;

    public DiceOption<T> Roll()
    {
        DiceOption<T> result = dice.Roll();
        displaySpriteRenderer.sprite = result.sprite;

        Debug.Log("Rolled " + result.name + " with " + gameObject.name);

        return result;
    }
}
