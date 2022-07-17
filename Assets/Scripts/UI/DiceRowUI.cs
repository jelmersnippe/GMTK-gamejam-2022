using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceRowUI : MonoBehaviour
{
    public DieUI dieUIPrefab;
    public TextMeshProUGUI label;
    public RectTransform diceContainer;
    public Button rollButton;

    public void UpdateDiceUiItem(int index, Sprite sprite)
    {
        DieUI dieUI;

        if (index >= diceContainer.childCount)
        {
            Debug.Log("Created new die at index " + index);
            dieUI = Instantiate(dieUIPrefab, diceContainer);
        }
        else
        {
            Debug.Log("Fetching die at index " + index);
            dieUI = diceContainer.GetChild(index).GetComponent<DieUI>();
        }

        Debug.Log("sprite != null" + sprite != null);
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
