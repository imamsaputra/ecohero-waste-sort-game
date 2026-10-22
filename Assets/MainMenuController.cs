using UnityEngine;
using UnityEngine.SceneManagement; // Wajib untuk mengatur perpindahan scene

public class MainMenuController : MonoBehaviour
{
    // 1. Dipanggil oleh tombol "Play" di Scene 1 (Scene_01_Welcome)
    public void PlayGame()
    {
        SceneManager.LoadScene("scene_03_gameplay");
    }

    // 2. Dipanggil oleh tombol "EXIT" di Scene 3 (Popup Failed / Finish)
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Scene_01_Welcome");
    }

    // 3. Dipanggil oleh tombol "REPLAY" di Scene 3 (Popup Failed / Finish)
    public void RestartGame()
    {
        SceneManager.LoadScene("scene_03_gameplay");
    }
}