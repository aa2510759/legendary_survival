using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class gameOverManager : MonoBehaviour
{
    public Text text;
    public string winText = "You Win!!!";
    public string LoseText = "Game Over";
    void Start()
    {
        if (CharacterCollisions.letsago == true)
        {
            text.text = winText;
            CharacterCollisions.letsago = false;

        }
        else text.text = LoseText;

    }
}
