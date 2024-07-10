using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class buttonSpriteChanger : MonoBehaviour
{
    public Button button;
    public SceneLoader loader;

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
        UnityEngine.Debug.Log(spriteTag);
        loader.LoadScene("Main Room");
    }
}
