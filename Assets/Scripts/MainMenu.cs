using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject instructionsPanel; // Reference to the instructions panel

    // Function to show instructions
    public void ShowInstructions()
    {
        instructionsPanel.SetActive(true); // Show the instructions panel
    }

    // Function to hide instructions
    public void HideInstructions()
    {
        instructionsPanel.SetActive(false); // Hide the instructions panel
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Sprint3"); // match this to your actual scene name
    }

    public void ExitGame()
    {
        Debug.Log("Your application is closed");
        Application.Quit();
    }
}
