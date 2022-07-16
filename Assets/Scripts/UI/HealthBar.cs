using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fill;
    public RectTransform container;

    public void SetFill(float percentage)
    {
        fill.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, percentage * container.rect.width);
    }
}
