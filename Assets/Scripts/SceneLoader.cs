using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}
