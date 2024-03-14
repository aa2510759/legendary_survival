using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelLogic : MonoBehaviour
{
    public GameObject dataGameObject; // Reference to the GameObject with the data
    public Text displayText; // Reference to the Text component to display the data

    // Update is called once per frame
    void Update()
    {
        // Check if the references are assigned
        if (dataGameObject != null && displayText != null)
        {
            // Access the int data from the GameObject (replace "YourComponent" and "YourIntVariable" with your actual component and variable names)
            int dataValue = dataGameObject.GetComponent<StatsScript>().hp;

            // Update the UI Text to display the fetched data
            displayText.text = "hp: " + dataValue.ToString();
        }
    }
}
