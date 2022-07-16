using UnityEngine;

public class FaceMousePosition : MonoBehaviour
{
    void Update()
    {
        if (Time.timeScale > 0f)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, MousePosition.GetAngleToMouse(transform.position)));
        }
    }
}
