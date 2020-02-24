using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private GameSession gameStatus;

    private void Awake() => gameStatus = FindObjectOfType<GameSession>();

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        gameStatus.ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
