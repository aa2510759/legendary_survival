using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] audioClips;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(int index)
    {
        if (source == null)
        {
            Debug.LogWarning("Source not found");
        }
        else
        {
            if (index >= 0 && index < audioClips.Length)
            {
                source.PlayOneShot(audioClips[index]);
            }
            else
            {
                Debug.LogWarning("Index out of range of audioClips array");
            }
        }
    }

    public void PlayAppleSound()
    {
        PlaySound(0);
    }

    public void PlayPickupSound()
    {
        PlaySound(1);
    }
    public void PlayShootSound()
    {
        PlaySound(2);
    }

    public void PlayLaughSound()
    {
        PlaySound(3);
    }

}