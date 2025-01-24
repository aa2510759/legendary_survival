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


    public bool leftBulletForce = false;
    public bool rightBulletForce = false;

    


    //public bool downBulletForce = false;
    //   public bool upBulletForce = false;

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
        if (Input.GetKeyDown(KeyCode.A))
        {
            print("Looking Left");
            characterShoot.shootPoint.position = new Vector3(charObj.transform.position.x + -0.42f, charObj.transform.position.y + 0.34f, 0);
            characterShoot.shootPoint.rotation = new Quaternion(0, 0,0,0);
            characterShoot.currentGunSprite.flipX = true;

            leftBulletForce = true;
            rightBulletForce = false;



          //  upBulletForce = false;
          //  downBulletForce = false;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            print("Looking Right");
            characterShoot.shootPoint.position = new Vector3(charObj.transform.position.x + 0.42f, charObj.transform.position.y + 0.34f, 0);
            characterShoot.shootPoint.rotation = new Quaternion(0, 0, 0, 0);
            characterShoot.currentGunSprite.flipX = false;

            rightBulletForce = true;
             leftBulletForce = false;



         //   upBulletForce = false;
         //   downBulletForce = false;
        }

        //***********************************************Scarpped code for shooting up and down keeping it simple and just horizontal shooting 
        /*else if (Input.GetKeyDown(KeyCode.W))
        {
            print("Looking Up");
            characterShoot.shootPoint.position = new Vector3(charObj.transform.position.x, charObj.transform.position.y + 1.5f, 0);
            characterShoot.shootPoint.rotation = new Quaternion(0, 0, 40, 0);

            upBulletForce = true;
            leftBulletForce = false;
            downBulletForce = false;
            downBulletForce = false;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            print("Looking Down");
            characterShoot.shootPoint.position = new Vector3(charObj.transform.position.x + -.25f, charObj.transform.position.y + -.5f, 0);
            characterShoot.shootPoint.rotation = new Quaternion(0, 0, 0, 0);

            downBulletForce = true;
            leftBulletForce = false;
            upBulletForce = false;
            rightBulletForce = false;
        }*/


        float moveX = Input.GetAxisRaw("Horizontal"); //CHECKING FOR A OR D INPUTS 
        float moveY = Input.GetAxisRaw("Vertical"); //CHECKING FOR S OR W INPUTS 

        moveDirection = new Vector2(moveX, moveY).normalized;  //normalized simply Returns this vector with a magnitude of 1 EX:without it 

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            menu.display();
        }


        if (Input.GetMouseButtonDown(0) && menu.panel.activeSelf == false) // 0 is the left mouse button
        {
            //Debug.Log("Insert Shoot here lol");

              if(characterShoot.charManager.gunEquipped == true && characterShoot.charManager.currentGun.Ammo > 0)
              {
            soundManager.PlayShootSound();
                characterShoot.Shoot();
            }
            
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
