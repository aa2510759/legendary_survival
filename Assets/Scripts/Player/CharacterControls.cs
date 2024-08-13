using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControls : MonoBehaviour
{
    public static GameObject charObj;
    public MenuLogic menu;
    public CharacterShoot characterShoot;
    public Rigidbody2D myRigidbody;
    public float Speed;
    private Vector2 moveDirection;
    public Sprite Hunter;
    public Sprite Mercenary;
    public Sprite Cop;

    public SoundManager soundManager;

    void Start()
    {
        charObj = this.gameObject;
        print(charObj);
        characterShoot = GetComponent<CharacterShoot>();

        if (characterShoot == null)
        {
            Debug.Log("Not found :(");
        }
        Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();

        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<MenuLogic>();
        sprites["Hunter"] = Hunter;
        sprites["Mercenary"] = Mercenary;
        sprites["Cop"] = Cop;
        if (gameObject != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[CharacterManager.spriteChoice];
        }
        else Debug.Log("gameObject not found..");

    }

    void Update()
    {
        ProcessInputs(); //CHECKING FOR MOVEMENT INPUT
    }

    //NOTE: FIXEDUPDATED GETS CALLED A SET AMOUNT OF TIMES DOESNT DEPEND ON YOUR FRAMERATE LIKE UPDATE THIS IS USUALLY USED FOR PHSYIC CALUACTIONS 

    void FixedUpdate()
    {
        Move(); //APPLYING MOVEMENT IF INPUT WAS DETECTED
        UpdateAnimation(); // Check if the character is moving and update the animation
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


        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            //Debug.Log("Insert Shoot here lol");
            soundManager.PlayShootSound();
            characterShoot.Shoot();
        }

       
    }

    void Move()
    {
        myRigidbody.velocity = new Vector2(moveDirection.x * (Speed + CharacterManager.speed), moveDirection.y * (Speed + CharacterManager.speed)) * Time.deltaTime;
        // print("Based Speed: " + Speed +
        //   "Speed Buff: " + CharacterManager.speed);
        
    }

    void UpdateAnimation()
    {
        
        bool isMoving = moveDirection != Vector2.zero;

        // Update the Walking boolean in the Animator
        if(CharacterManager.characterAnimReference != null)
        {
            CharacterManager.characterAnimReference.SetBool("Walking", isMoving);
        }
        else
        {
            print("Animator is null " + CharacterManager.characterAnimReference);
        }
         
    }
}
