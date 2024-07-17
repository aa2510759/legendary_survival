using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject obj;


    public int x;
    public int y;

    public Vector2 vector2;

    public int randomSpawnAmount;
    // Start is called before the first frame update
    void Start()
    {
        randomSpawnAmount = UnityEngine.Random.Range(0, 10);

        for (int i = 0; i < randomSpawnAmount; i++)
        {
            //print("Tree should spawn here");
            GameObject clone = Instantiate(obj);
            x = UnityEngine.Random.Range(-5, 5);
            y = UnityEngine.Random.Range(-5, 5);
            //print("Vector2: " + "X: " + x.ToString() +"Y: " + y.ToString());
            vector2 = new Vector2(x, y);

            clone.transform.position = vector2;

        }
    }
}
