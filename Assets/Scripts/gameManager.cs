using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static gameManager instance;

    public static bool isGameEnd = false;

    public GameObject varman;
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
        VariableManager.hunger = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (VariableManager.hunger == 0 && isGameEnd == false)
        {
            //  UnityEngine.Debug.Log("You died...");
            isGameEnd = true;
            SceneManager.LoadScene(5);
            varman = GameObject.FindWithTag("Variable Manager");
            Destroy(varman);
        }
    }
}
