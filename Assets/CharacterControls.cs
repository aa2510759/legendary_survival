using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float Speed;
    // Start is called before the first frame update
    private string userInput;
    void Start()
    {
        Debug.Log("Hi");
    }

    // Update is called once per frame
    void Update()
    {
        userInput = Input.inputString;
        switch (userInput)
        {
            case "w":
                Debug.Log("Moving forward");
                myRigidbody.velocity = Vector2.up * Speed;
                break;
            case "a":
                Debug.Log("Moving left");
                myRigidbody.velocity = Vector2.left * Speed;
                break;
            case "s":
                Debug.Log("Moving down");
                myRigidbody.velocity = Vector2.down * Speed;
                break;
            case "d":
                Debug.Log("Moving right");
                myRigidbody.velocity = Vector2.right * Speed;
                break;
        }
    }
}
