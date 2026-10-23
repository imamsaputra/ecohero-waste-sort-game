using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void MainGame()
    {
        SceneManager.LoadScene("Scene_02_Gameplay");
    }

    public void KeluarGame()
    {
        Application.Quit();
    }
}