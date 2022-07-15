using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class DiceDisplay : MonoBehaviour
{
    public Dice<Color> dice;
    public SpriteRenderer spriteRenderer;

    private void OnMouseDown()
    {
        DiceOption<Color> result = dice.Roll();
        spriteRenderer.color = result.value;
    }
}
