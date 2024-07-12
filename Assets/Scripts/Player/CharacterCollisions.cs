using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCollisions : MonoBehaviour
{
    public MenuLogic menu;
    public CharacterShoot characterShoot;

    private void OnTriggerEnter2D(Collider2D other)
    {
        string objTag = other.gameObject.tag;
        Debug.Log("Objtag = " + objTag);
        if (objTag == "Apple") { CharacterManager.hunger += 5; }
        else if (objTag == "Enemy") { CharacterManager.hp -= 15; }
        else if (objTag == "Untagged") { Debug.Log("Untagged Collision"); }
        else SceneManager.LoadScene(objTag);
    }
}
