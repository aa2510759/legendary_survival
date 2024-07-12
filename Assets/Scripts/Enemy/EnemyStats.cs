using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float Health = 50;
    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string objTag = other.gameObject.tag;

        if (objTag == "Player")
        {
            Health -= 25;
            //Debug.Log("I got hit!!!!!!!!!!!!");
        }
    }
}
