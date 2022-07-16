using UnityEngine;
using UnityEngine.UI;

public class DieUI : MonoBehaviour
{
    public Image display;

    public void SetDisplay(Sprite sprite)
    {
        display.sprite = sprite;
    }
}
