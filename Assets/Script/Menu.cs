using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayeGame()
    {
        SceneManager.LoadScene("BeforeLevel1");
    }
    
    public void PlayGame2()
    {
        SceneManager.LoadScene("BeforeLevel2");
    }

    public void PlayGame3()
    {
        SceneManager.LoadScene("BeforeLevel3");
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
