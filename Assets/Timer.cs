using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    public float timerInterval = 5f;
    private float timer; // Timer to keep track of elapsed time

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
    }
    void Start()
    {
        // Start the coroutine when the script is initialized
        StartCoroutine(TimerCheck());
    }

    // Coroutine to check ticks every n seconds
    IEnumerator TimerCheck()
    {
        while (true)
        {
            // Wait for the specified time interval
            yield return new WaitForSeconds(timerInterval);
            VariableManager.hunger--;
            float hunger = VariableManager.hunger;
            Debug.Log("Hunger: " + hunger);
        }
    }
}