using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class buttonSpriteChanger : MonoBehaviour
{
    public Button button;
    public SceneLoader loader;

    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }
    public void OnButtonClick()
    {
        string parentTag = transform.parent.gameObject.tag;
        VariableManager.spriteChoice = parentTag;
        UnityEngine.Debug.Log(parentTag);
        loader.LoadScene("Main Room");
    }
}
