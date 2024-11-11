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
        gameOverUI.SetActive(false);

        respawnButton.onClick.AddListener(RespawnPlayer);
        quitButton.onClick.AddListener(QuitGame);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
    }

    public void ShowGameOverUI()
    {
        Debug.Log("ShowGameOverUI called");
        gameOverUI.SetActive(true);
        Debug.Log("gameOverUI active: " + gameOverUI.activeSelf);
    }

    public void RespawnPlayer()
    {
        // Hide the Game Over UI
        gameOverUI.SetActive(false);

        // Respawn the player
        PlayerManager.instance.RespawnPlayer();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
