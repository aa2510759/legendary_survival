using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControls : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        string objTag = other.gameObject.name;
        Debug.Log("Objtag = " + objTag);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public Rigidbody2D myRigidbody;
    public float Speed;
    // Start is called before the first frame update
    private string userInput;


    void Start()
    {
        //Debug.Log("Hi");
    }

    // Update is called once per frame
    void Update()
    {
        userInput = Input.inputString;
        switch (userInput)
        {
            case "w":
                //Debug.Log("Moving up");
                myRigidbody.velocity = Vector2.up * Speed;
                break;
            case "a":
                //Debug.Log("Moving left");
                myRigidbody.velocity = Vector2.left * Speed;
                break;
            case "s":
                //Debug.Log("Moving down");
                myRigidbody.velocity = Vector2.down * Speed;
                break;
            case "d":
                //Debug.Log("Moving right");
                myRigidbody.velocity = Vector2.right * Speed;
                break;
        }
    }
}
