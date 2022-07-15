using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class DiceDisplay<T> : MonoBehaviour
{
    public Dice<T> dice;
    public SpriteRenderer displaySpriteRenderer;

    public DiceOption<T> Roll()
    {
        DiceOption<T> result = dice.Roll();
        displaySpriteRenderer.sprite = result.sprite;

        return result;
    }
}
