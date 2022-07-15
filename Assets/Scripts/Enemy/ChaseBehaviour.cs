using UnityEngine;

public class ChaseBehaviour : MonoBehaviour
{
    public float speed = 4f;
    public Transform target;

    private void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player")?.transform;
        }
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
