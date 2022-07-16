using UnityEngine;
using TMPro;

public class PauseController : MonoBehaviour
{
    public GameObject pauseOverlay;
    public TextMeshProUGUI titleUI;
    public GameObject continueButton;

    public bool isGameOver = false;
    public bool overlayActive = false;

    private float initialTimeScale = 1f;

    private void Update()
    {
        if (isGameOver)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (overlayActive)
            {
                Disable();
            }
            else
            {
                Enable();
            }
        }
    }

    public void Enable()
    {
        initialTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        pauseOverlay.SetActive(true);
        overlayActive = true;
    }

    public void Disable()
    {
        Time.timeScale = initialTimeScale;
        pauseOverlay.SetActive(false);
        overlayActive = false;
    }

    public void SetGameOver()
    {
        isGameOver = true;
        titleUI.text = "GAME OVER";
        continueButton.SetActive(false);
        Enable();
    }
}
