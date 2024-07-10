using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControls : MonoBehaviour
{
    public MenuLogic menu;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // replaced the dictionary with tags that are identical to the scene names
        string objTag = other.gameObject.tag;
        Debug.Log("Objtag = " + objTag);
        if (objTag == "Apple") { VariableManager.hunger += 5; }
        if (objTag == "Enemy") { VariableManager.hp -= 15; }
        else SceneManager.LoadScene(objTag); //this should most likely be in it's own script outside of CharacterControls
    }
    public Rigidbody2D myRigidbody;
    public float Speed;

    private Vector2 moveDirection;

    // Start is called before the first frame update
    private string userInput;

    public Sprite Hunter;
    public Sprite Mercenary;
    public Sprite Cop;

    void Start()
    {
        Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();

        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<MenuLogic>();
        sprites["Hunter"] = Hunter;
        sprites["Mercenary"] = Mercenary;
        sprites["Cop"] = Cop;
        if (gameObject != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[VariableManager.spriteChoice]; ;
        }
        else Debug.Log("gameObject not found..");

    }

    // Update is called once per frame depends on your framerate
    void Update()
    {
        ProcessInputs(); //CHECKING FOR MOVEMENT INPUT
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
            menu.display();
        }
    }

    void Move()
    {
        myRigidbody.velocity = new Vector2(moveDirection.x * (Speed + VariableManager.speed), moveDirection.y * (Speed + VariableManager.speed)) * Time.deltaTime;
        print("Based Speed: " + Speed +
            "Speed Buff: " + VariableManager.speed);
    }
}
