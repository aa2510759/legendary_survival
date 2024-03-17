using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class VariableManager : MonoBehaviour
{
    public static VariableManager instance;

    // Start is called before the first frame update

    public static string spriteChoice;
    public static float hp = 100;
    public static float hunger = 90;
    public static float speed = 80;

    public static float defense = 70;
    public static float attack = 60;
    public static float gold = 50;

    public static float x = 0;
    public static float y = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
    }

    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
    }
    void Update()
    {
        x = transform.position.x;
        y = transform.position.y;
    }
}
