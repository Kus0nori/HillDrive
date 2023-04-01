using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Scenes/Level");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
