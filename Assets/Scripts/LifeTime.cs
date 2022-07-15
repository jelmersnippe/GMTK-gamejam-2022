using UnityEngine;

public class LifeTime : MonoBehaviour
{
    public float lifetime = 1f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
