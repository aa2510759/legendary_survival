using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class buttonStartOver : MonoBehaviour
{
    public Button button;
    public SceneLoader loader;

    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }
    public void OnButtonClick()
    {
        loader.LoadScene("Character Select");
    }
}
