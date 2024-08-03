using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] obj;


    public int x;
    public int y;

    public Vector2 vector2;

    public int randomSpawnAmount;

    public bool spawnCustom = true;

    public int customX;
    public int customY;

    // Start is called before the first frame update
    void Start()
    {
        randomSpawnAmount = UnityEngine.Random.Range(0, 10);


        //Merchant spawn IF STATEMENT RIGHT HERE ************
        if(spawnCustom == true && (randomSpawnAmount % 2) == 0)
        {
            spawnCustom = false;
            GameObject clone = Instantiate(obj[1]);

            customX = 3;
            customY = 2;

            vector2 = new Vector2(customX, customY);

            clone.transform.position = vector2;
        }

        for (int i = 0; i < randomSpawnAmount; i++)
        {
            //print("Tree should spawn here");
            GameObject clone = Instantiate(obj[0]);
            x = UnityEngine.Random.Range(-5, 5);
            y = UnityEngine.Random.Range(-5, 5);
            //print("Vector2: " + "X: " + x.ToString() +"Y: " + y.ToString());
            vector2 = new Vector2(x, y);

            clone.transform.position = vector2;

        }

    }
}
