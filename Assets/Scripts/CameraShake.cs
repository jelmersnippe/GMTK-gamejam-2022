using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPosition;
    public static CameraShake instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }

    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(ShakeRoutine(duration, magnitude));
    }

    private IEnumerator ShakeRoutine(float duration, float magnitude)
    {
        originalPosition = transform.localPosition;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            Vector3 shakeOffset = Random.insideUnitSphere * magnitude;

            transform.localPosition = originalPosition + new Vector3(shakeOffset.x, shakeOffset.y, originalPosition.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        Debug.Log(originalPosition);
        transform.localPosition = originalPosition;
    }
}
