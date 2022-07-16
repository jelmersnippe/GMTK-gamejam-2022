using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private void OnEnable()
    {
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        Cursor.visible = true;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        Vector3 mousePosition = MousePosition.Get();
        transform.position = new Vector3(mousePosition.x, mousePosition.y);
    }
}
