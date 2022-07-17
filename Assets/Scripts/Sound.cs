using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip source;
    [Range(-3, 3)]
    public float minPitch;
    [Range(-3, 3)]
    public float maxPitch;
    [Range(0, 1)]
    public float minVolume;
    [Range(0, 1)]
    public float maxVolume;
}