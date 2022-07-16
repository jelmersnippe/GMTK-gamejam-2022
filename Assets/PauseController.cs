using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject pauseOverlay;
    public bool overlayActive = false;

    private float initialTimeScale;

    private void Update()
    {
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
}
