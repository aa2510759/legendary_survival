using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class Timer : MonoBehaviour
{
    private float timerInterval = 2f;
    private float timer; // Timer to keep track of elapsed time

    public GameObject dataGameObject;

    // Start is called before the first frame update
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


            // Perform your action here every n seconds

            dataGameObject.GetComponent<StatsScript>().hp -= 1;
            int n = dataGameObject.GetComponent<StatsScript>().hp;
            Debug.Log(timerInterval + " seconds have passed...");


            //Debug.Log("HP went down..");
            Debug.Log("HP: " + n);

        }
    }
}