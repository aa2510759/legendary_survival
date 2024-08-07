using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public static Timer instance;



    public float timerInterval = 5f;


    void Awake()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 5)
        {
            Destroy(this.gameObject);
        }
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
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        while (currentSceneIndex != 0)
        {
            // Wait for the specified time interval
            yield return new WaitForSeconds(timerInterval);
            CharacterManager.hunger--;

        }
    }

    void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            // CharacterManager.hp = 100;
            // CharacterManager.hunger = 10;
        }
    }
}