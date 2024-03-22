using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static gameManager instance;

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

    }

    // Update is called once per frame
    void Update()
    {
        if (VariableManager.hunger == 0)
        {
            UnityEngine.Debug.Log("You died...");
            VariableManager.hunger = 10;
            SceneManager.LoadScene(5);
            varman = GameObject.FindWithTag("Variable Manager");
            Destroy(varman);
        }
    }
}
