using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
    // Start is called before the first frame update

    void OnTriggerEnter2D()
    {
        Debug.Log("Were in!");
        Destroy(gameObject);
        // Check if the colliding GameObject has a specific tag (optional)
        // if (other.CompareTag("Player"))
        // {
        //     // Destroy the GameObject attached to this script
        //     Destroy(gameObject);
        // }
    }

    void Awake()
    {
        if (VariableManager.hunger % 2 == 0)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
