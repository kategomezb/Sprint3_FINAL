using UnityEngine;

public class GamePause : MonoBehaviour
{
    private bool isPaused = false; // Track whether the game is paused or not

    void Update()
    {
        // Toggle pause state when the P key is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    void PauseGame()
    {
        // Freeze the game by setting time scale to 0
        Time.timeScale = 0f;
        isPaused = true;
        Debug.Log("Game Paused");
    }

    void ResumeGame()
    {
        // Unfreeze the game by setting time scale to 1
        Time.timeScale = 1f;
        isPaused = false;
        Debug.Log("Game Resumed");
    }
}
