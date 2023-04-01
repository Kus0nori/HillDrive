using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private UIController uiController;
    public bool levelIsRunning = true;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        uiController.UIGameOver();
        levelIsRunning = false;
        Time.timeScale = 0f;
    }

    public void PauseGame()
    {
        uiController.UIPauseMenu();
        Time.timeScale = 0f;
        levelIsRunning = false;
    }

    public void ContinueGame()
    {
        levelIsRunning = true;
        Time.timeScale = 1f;
    }

    public void DoVictory()
    {
        uiController.UIVictory();
        Time.timeScale = 0f;
        levelIsRunning = false;
    }
}
