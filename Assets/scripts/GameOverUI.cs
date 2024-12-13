using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverUI;
    public Button respawnButton;
    public Button quitButton;
    public Button mainMenuButton;

    void Start()
    {
        // Ensure the Game Over UI is hidden initially
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }
        else
        {
            Debug.LogError("GameOverUI is not assigned.");
        }

        // Add listeners to the buttons
        if (respawnButton != null)
        {
            respawnButton.onClick.AddListener(RespawnPlayer);
        }
        else
        {
            Debug.LogError("RespawnButton is not assigned.");
        }

        if (quitButton != null)
        {
            quitButton.onClick.AddListener(QuitGame);
        }
        else
        {
            Debug.LogError("QuitButton is not assigned.");
        }

        if (mainMenuButton != null)
        {
            mainMenuButton.onClick.AddListener(ReturnToMainMenu);
        }
        else
        {
            Debug.LogError("MainMenuButton is not assigned.");
        }
    }

    public void ShowGameOverUI()
    {
        Debug.Log("ShowGameOverUI called");
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
            Debug.Log("gameOverUI active: " + gameOverUI.activeSelf);

            // Disable player controls
            PlayerManager.instance.player.GetComponent<PlayerMovement>().enabled = false;
            PlayerManager.instance.player.GetComponent<PlayerCam>().enabled = false;

            // Unlock and show the cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Pause the game
            Time.timeScale = 0f;
        }
        else
        {
            Debug.LogError("GameOverUI is not assigned.");
        }
    }

    public void RespawnPlayer()
    {
        // Hide the Game Over UI
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }

        // Respawn the player
        PlayerManager.instance.RespawnPlayer();

        // Enable player controls
        PlayerManager.instance.player.GetComponent<PlayerMovement>().enabled = true;
        PlayerManager.instance.player.GetComponent<PlayerCam>().enabled = true;

        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Resume the game
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        // Resume the game before loading the main menu
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
