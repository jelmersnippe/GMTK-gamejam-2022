using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public Sound[] sounds;
    public AudioSource audioSource;

    public float timeBetweenSounds = 0.5f;
    private float timeRemainingToNextSound;

    public void Update()
    {
        if (timeRemainingToNextSound > 0f)
        {
            timeRemainingToNextSound -= Time.deltaTime;
        }
    }

    public void Move(Vector2 input)
    {
        if (input != Vector2.zero && timeRemainingToNextSound <= 0f && sounds.Length > 0)
        {
            int soundIndex = Random.Range(0, sounds.Length);
            AudioManager.PlaySound(audioSource, sounds[soundIndex]);
            timeRemainingToNextSound = timeBetweenSounds;
        }

        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(input.x, input.y), speed * Time.deltaTime);
    }
}
