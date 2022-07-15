using UnityEngine;

public static class MousePosition
{
    public static Vector3 Get()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public static float GetAngleToMouse(Vector3 origin)
    {
        Vector3 mousePosition = MousePosition.Get();
        return Mathf.Atan2(mousePosition.y - origin.y, mousePosition.x - origin.x) * Mathf.Rad2Deg;
    }
}
