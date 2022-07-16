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

    public void UpdateDiceUiItem(int index, Sprite sprite)
    {
        DieUI dieUI;

        if (index >= diceContainer.childCount)
        {
            dieUI = Instantiate(dieUIPrefab, diceContainer);
        }
        else
        {
            dieUI = diceContainer.GetChild(index).GetComponent<DieUI>();
        }

        dieUI.display.gameObject.SetActive(sprite != null);
        dieUI.SetDisplay(sprite);
    }

    public void Clear()
    {
        foreach (RectTransform child in diceContainer)
        {
            Destroy(child.gameObject);
        }
    }
}
