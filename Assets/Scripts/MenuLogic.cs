using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLogic : MonoBehaviour
{
    public GameObject charcter;
    public GameObject panel;
    public void display()
    {
        if (panel != null)
        {
            if (panel.activeSelf) panel.SetActive(false);
            else panel.SetActive(true);
        }

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
