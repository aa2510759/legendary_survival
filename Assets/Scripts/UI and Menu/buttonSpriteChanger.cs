using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonSpriteChanger : MonoBehaviour
{
    public Button button;
    public GameObject VariableManager;

    public static string spriteTag;

    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }
    public void OnButtonClick()
    {
        spriteTag = transform.parent.gameObject.tag;
        VariableManager.SetActive(true);
        //UnityEngine.Debug.Log(spriteTag);
        SceneManager.LoadScene("Main Room");
    }
}
