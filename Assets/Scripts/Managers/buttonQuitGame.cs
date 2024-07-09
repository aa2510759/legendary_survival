using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Function to quit the game
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}