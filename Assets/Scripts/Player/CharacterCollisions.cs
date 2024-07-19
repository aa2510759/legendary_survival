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
        Debug.Log("Objtag = " + objTag);
        if (objTag == "Apple")
        {
            CharacterManager.hunger += 5;
            soundManager.playSound();
        }
        else if (objTag == "Enemy") { CharacterManager.hp -= 15; }
        else if (objTag == "Untagged") { Debug.Log("Untagged Collision"); }
        else
        {

            SceneManager.LoadScene(objTag);
            CharacterManager.daysPassed++;

            if (CharacterManager.daysPassed > 5)
            {
                CharacterManager.daysPassed = 0;
                gameManager game = FindObjectOfType<gameManager>();
                Debug.Log("You win!!!");
                letsago = true;
                game.EndGame();

            }
        }
    }
}
