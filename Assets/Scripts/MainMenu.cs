using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This class controls the main menu of the game
public class MainMenu : MonoBehaviour
{
    // This method is called when the "Play Game" button is clicked
    public void PlayGame()
    {
        // Load the next scene in the build index, which is the game scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // This method is called when the "Quit Game" button is clicked
    public void QuitGame()
    {
        // Log a message to the console
        Debug.Log("Quitter");

        // Quit the application
        Application.Quit();
    }
}
