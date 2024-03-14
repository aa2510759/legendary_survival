using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControls : MonoBehaviour
{
    public MenuLogic menu;
    public MainLogic logic;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Dictionary<string, int> scenes = new Dictionary<string, int>();
        scenes["Main"] = 0;
        scenes["Forest"] = 1;
        scenes["Town"] = 2;
        scenes["City"] = 3;
        string objTag = other.gameObject.name;
        Debug.Log("Objtag = " + objTag);
        SceneManager.LoadScene(scenes[objTag]);
    }
    public Rigidbody2D myRigidbody;
    public float Speed;

    private Vector2 moveDirection;

    // Start is called before the first frame update
    private string userInput;


    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<MenuLogic>();

    }

    // Update is called once per frame depends on your framerate
    void Update()
    {

        ProcessInputs(); //CHECKING FOR MOVEMENT INPUT
        //ANDRES CODE
        /*
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

             default:
                myRigidbody.velocity = Vector2.zero;
                break;

        }
    */
    }

    //NOTE: FIXEDUPDATED GETS CALLED A SET AMOUNT OF TIMES DOESNT DEPEND ON YOUR FRAMERATE LIKE UPDATE THIS IS USUALLY USED FOR PHSYIC CALUACTIONS 

    void FixedUpdate()
    {
        Move(); //APPLYING MOVEMENT IF INPUT WAS DETECTED
    }


    void ProcessInputs()
    {

        float moveX = Input.GetAxisRaw("Horizontal"); //CHECKING FOR A OR D INPUTS 
        float moveY = Input.GetAxisRaw("Vertical"); //CHECKING FOR S OR W INPUTS 

        moveDirection = new Vector2(moveX, moveY).normalized;  //normalized simply Returns this vector with a magnitude of 1 EX:without it 

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("call menu function...");
            menu.display();
            //logic.displayMenu();
        }

    }



    void Move()
    {
        myRigidbody.velocity = new Vector2(moveDirection.x * Speed, moveDirection.y * Speed) * Time.deltaTime;
    }
}
