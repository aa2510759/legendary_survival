using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class CharacterCollisions : MonoBehaviour
{
    public MenuLogic menu;
    public CharacterShoot characterShoot;
    public SoundManager soundManager;
    public static bool letsago = false;

     


    private void OnTriggerEnter2D(Collider2D other)
    {

        string objTag = other.gameObject.tag;
        //Debug.Log("Objtag = " + objTag);
        if (objTag == "Apple")
        {
            CharacterManager.hunger += 5;
            soundManager.PlayAppleSound();
        }
        else if (objTag == "Enemy") { CharacterManager.hp -= 15; }
        else if (objTag == "Untagged")
        {
            //Debug.Log("Untagged Collision");
            soundManager.PlayPickupSound();
        }
        else
        {
            print("Entered: " + objTag + " Scene");

            NextSceneSystem sceneScript =  other.gameObject.GetComponent<NextSceneSystem>();

            print("Left: " + sceneScript.left + " Right: " + sceneScript.right + " Up: " + sceneScript.up + " Down: " + sceneScript.down);
            //If Entering a Left scene then (X = -X And (Y || -Y) = itself), (Right -X = X and (Y || -Y) = itself), (Up (X || -X) = itself and Y = -Y), (Down (X || -X) = itself and -Y = Y)

          

                SceneManager.LoadScene(objTag);
            CharacterManager.daysPassed++;



            if (sceneScript.left == true)
            {
                Vector3 pos = new Vector3(-(transform.position.x + 0.5f), transform.position.y, 0);

                CharacterControls.SetNewPositionForNewScene(pos);
            }
            else if (sceneScript.right == true)
            {
                Vector3 pos = new Vector3(-(transform.position.x - 0.5f), transform.position.y, 0);

                CharacterControls.SetNewPositionForNewScene(pos);
            }
            else if (sceneScript.up == true)
            {
                Vector3 pos = new Vector3(transform.position.x, -(transform.position.y - .5f), 0); //.5 idk why this makes it work proper and be the same as going down (Look into this maybe idk where to look tbh already attempted resizing and matching the positions perfectly)

                CharacterControls.SetNewPositionForNewScene(pos);
            }                                                                                   
            else if (sceneScript.down == true)
            {
                Vector3 pos = new Vector3(transform.position.x, -(transform.position.y + 1.5f), 0);//1.5 idk why this makes it work proper and be the same as going up (Look into this maybe idk where to look tbh already attempted resizing and matching the positions perfectly)

                CharacterControls.SetNewPositionForNewScene(pos);
            }



            if (CharacterManager.daysPassed > 5)
            {

                CharacterManager.daysPassed = 0;
                gameManager game = FindObjectOfType<gameManager>();
                // Debug.Log("You win!!!");

                letsago = true;
                game.EndGame();

            }
        }
    }
}
