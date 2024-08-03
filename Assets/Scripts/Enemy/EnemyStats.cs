using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float Health = 50;
    public float Damage = 10;

    public GameObject goldItemDrop;
    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            GameObject clone = Instantiate(goldItemDrop);
            clone.transform.position = transform.position;
           
          
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string objTag = other.gameObject.tag;

        if (objTag == "PlayerBullet")
        {
            Health -= 25;
        }
    }
}
