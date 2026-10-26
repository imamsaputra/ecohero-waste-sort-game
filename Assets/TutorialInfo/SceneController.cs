using UnityEngine;
using UnityEngine.SceneManagement; // Wajib ada untuk mengatur scene

public class SceneController : MonoBehaviour
{
    // Fungsi untuk masuk ke gameplay (Scene 2)
    public void PlayGame()
    {
        SceneManager.LoadScene("Scene_02_WasteEncyclopedia"); // Ganti dengan nama Scene 2 kamu
    }

    // Fungsi untuk kembali ke menu utama (Scene 1)
    public void BackToMenu()
    {
        SceneManager.LoadScene("Scene_01_Main"); // Ganti dengan nama Scene 1 kamu
    }

    // Fungsi untuk keluar dari aplikasi
    public void QuitGame()
    {
        Debug.Log("Keluar Game...");
        Application.Quit();
    }
}