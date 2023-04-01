using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject hudCanvas;
    [SerializeField] private GameObject victoryCanvas;
    [SerializeField] private GameObject pauseMenuCanvas;
    [SerializeField] private Gradient fuelGradient;
    [SerializeField] private Image fuelImage;
    private void Update()
    {
        ChangeFuelMeter();
    }

    private void ChangeFuelMeter()
    {
        fuelImage.fillAmount = (FuelController.Instance.currentFuelAmount / FuelController.Instance.maxFuelAmount);
        fuelImage.color = fuelGradient.Evaluate(fuelImage.fillAmount);
    }

    public void UIPauseMenu()
    {
        pauseMenuCanvas.SetActive(true);
    }

    public void UIGameOver()
    {
        gameOverCanvas.SetActive(true);
        hudCanvas.SetActive(false);
    }

    public void UIVictory()
    {
        victoryCanvas.SetActive(true);
        hudCanvas.SetActive(false);
    }

    public void ContinueButton()
    {
        pauseMenuCanvas.SetActive(false);
        hudCanvas.SetActive(true);
        GameManager.Instance.ContinueGame();
    }

    public void ExitToMainMenuButton()
    {
        SceneManager.LoadScene("Scenes/Main Menu");
    }
    
    public void RestartLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
