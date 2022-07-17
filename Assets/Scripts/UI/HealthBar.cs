using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Image fill;
    public RectTransform container;
    public TextMeshProUGUI text;

    public void SetFill(int current, int max)
    {
        int clampedCurrent = Mathf.Clamp(current, 0, max);
        int clampedMax = Mathf.Max(max, current);
        fill.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ((float)clampedCurrent / (float)clampedMax) * container.rect.width);
        if (text != null)
        {
            text.text = current + " / " + max;
        }
    }
}
