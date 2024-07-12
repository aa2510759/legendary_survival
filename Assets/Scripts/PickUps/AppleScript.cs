using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
    void OnTriggerEnter2D()
    {
        Destroy(gameObject);
    }

    void Awake()
    {
        if (CharacterManager.hunger % 2 == 0)
        {
            Destroy(gameObject);
        }
    }
}
