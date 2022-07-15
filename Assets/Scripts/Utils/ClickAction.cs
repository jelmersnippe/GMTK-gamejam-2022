using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class ClickAction : MonoBehaviour
{
    public UnityEvent clickAction;

    private void OnMouseDown()
    {
        clickAction.Invoke();
    }
}
