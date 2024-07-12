using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    public static bool isGameEnd = false;


    

    public GameObject charMan;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
    }
    void Start()
    {
          
    }

    void Update()
    {
        if (CharacterManager.hunger == 0 && !isGameEnd)
        {
            EndGame();
        }
        else if (CharacterManager.hp <= 0 && !isGameEnd)
        {

            EndGame();
        }


    }
    void EndGame()
    {
        CharacterManager.hp = 0;
        UnityEngine.Debug.Log("Ending Game...");
        isGameEnd = true;
        charMan = GameObject.FindWithTag("CharacterManager");
        Destroy(charMan);
        SceneManager.LoadScene(5);
      
           
        
       

    }
}
