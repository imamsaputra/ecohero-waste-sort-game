using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // 1. Mengulang scene yang sedang dimainkan (Tombol Ulangi)
    public void RestartGame()
    {
        Time.timeScale = 1f; // Wajib dikembalikan ke 1 agar game tidak macet/pause
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 2. Keluar dari aplikasi / permainan (Tombol Exit)
    public void QuitGame()
    {
        Debug.Log("Keluar dari game...");
        Application.Quit();
    }

    // 3. Pergi ke Beranda Utama (Kembali ke Scene 1)
    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Kembalikan waktu normal sebelum pindah scene
        SceneManager.LoadScene("Scene_01_Welcome"); // Pastikan kembali ke Scene 1
    }

    // 4. Melanjutkan ke Level Berikutnya (Scene selanjutnya dari scene aktif)
    public void NextLevel()
    {
        Time.timeScale = 1f; // Kembalikan waktu normal
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}