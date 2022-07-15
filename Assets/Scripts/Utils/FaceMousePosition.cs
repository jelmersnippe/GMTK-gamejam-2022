using UnityEngine;

public class FaceMousePosition : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, MousePosition.GetAngleToMouse(transform.position)));
    }
}
