using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform followTarget;

    public void Update()
    {
        if (followTarget == null)
        {
            SetPlayerAsFollowTarget();
            return;
        }

        transform.position = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
    }

    public void SetPlayerAsFollowTarget()
    {
        followTarget = FindObjectOfType<PlayerInput>()?.transform;
    }
}
