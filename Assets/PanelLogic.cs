using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelLogic : MonoBehaviour
{
    public Text displayText;

    void Update()
    {
        if (displayText != null)
        {
            float dataValue = VariableManager.hunger;
            displayText.text = "hunger: " + dataValue.ToString();
        }
    }
}
