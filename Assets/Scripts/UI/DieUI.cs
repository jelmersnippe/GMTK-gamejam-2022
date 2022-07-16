using UnityEngine;
using UnityEngine.UI;

public class DieUI : MonoBehaviour
{
    public Image display;
    public Image lockDisplay;

    public Sprite lockClosedSprite;
    public Sprite lockOpenedSprite;

    public bool locked = false;

    public void SetDisplay(Sprite sprite)
    {
        display.sprite = sprite;
    }

    public void ToggleLocked()
    {
        locked = !locked;
        lockDisplay.sprite = locked ? lockClosedSprite : lockOpenedSprite;
    }
}
