using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class buttonStartOver : MonoBehaviour
{
    public Button button;
    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }
    public void OnButtonClick()
    {
        CharacterManager.hp = 100;
        // Debug.Log("Loading Character Select...");
        gameManager.isGameEnd = false;
        SceneManager.LoadScene("Character Select");

    }
}
