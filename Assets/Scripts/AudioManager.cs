using UnityEngine;
using UnityEngine.Audio;

public static class AudioManager
{
    // [Range(0, 1)]
    // [SerializeField] private float volumeModifier = 1;

    public static void PlaySound(AudioSource audioSource, Sound sound)
    {
        float pitch = UnityEngine.Random.Range(sound.minPitch, sound.maxPitch);
        float volume = UnityEngine.Random.Range(sound.minVolume, sound.maxVolume);
        audioSource.pitch = pitch;
        audioSource.volume = volume;
        audioSource.PlayOneShot(sound.source);
    }

    // void UpdateVolume(int newVolume)
    // {
    //     volumeModifier = newVolume / 100f;
    // }
}
