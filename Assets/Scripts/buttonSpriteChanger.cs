using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class buttonSpriteChanger : MonoBehaviour
{
    public Button button;

    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }
    public void OnButtonClick()
    {
        string parentTag = transform.parent.gameObject.tag;
        VariableManager.spriteChoice = parentTag;
        UnityEngine.Debug.Log(parentTag);
    }
}
