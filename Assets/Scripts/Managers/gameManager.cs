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
        CharacterManager.hunger = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (CharacterManager.hunger == 0 && isGameEnd == false)
        {
            isGameEnd = true;
            SceneManager.LoadScene(5);
            charMan = GameObject.FindWithTag("CharacterManager");
            Destroy(charMan);
        }
    }
}
