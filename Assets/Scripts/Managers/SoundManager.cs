using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource soundSource;

    void Start()
    {
        soundSource = GetComponent<AudioSource>();
    }

    public void playSound()
    {
        if (soundSource != null)
        {
            soundSource.Play();
        }
        else
        {
            Debug.LogWarning("Sound not found");
        }
    }

}