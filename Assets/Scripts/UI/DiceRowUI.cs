using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceRowUI : MonoBehaviour
{
    public DieUI dieUIPrefab;
    public TextMeshProUGUI label;
    public RectTransform diceContainer;
    public Button rollButton;

    private void Start()
    {
        Clear();
    }

    public void AddDiceUiItem(Sprite sprite)
    {
        DieUI createdUI = Instantiate(dieUIPrefab, diceContainer);

        createdUI.display.gameObject.SetActive(sprite != null);
        createdUI.SetDisplay(sprite);
    }

    public void Clear()
    {
        foreach (RectTransform child in diceContainer)
        {
            Destroy(child.gameObject);
        }
    }
}
