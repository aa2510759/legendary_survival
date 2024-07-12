using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonStartOver : MonoBehaviour
{
    public Button button;
    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }
    public void OnButtonClick()
    {
        gameManager.isGameEnd = false;
        SceneManager.LoadScene("Character Select");
    }
}
