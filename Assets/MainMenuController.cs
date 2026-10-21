using UnityEngine;
using UnityEngine.SceneManagement; // Wajib untuk memindahkan scene

public class MainMenuController : MonoBehaviour
{
    // Fungsi yang dipanggil oleh tombol Play di Scene 1
    public void PlayGame()
    {
        SceneManager.LoadScene("scene_03_gameplay");
    }

    // Fungsi yang dipanggil oleh tombol Exit di Scene 3 untuk kembali ke Scene 1
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Scene_01_Welcome");
    }
}