using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Daftar Pop-up Finish per Level")]
    public GameObject[] listPopupFinish;

    [Header("Daftar Pop-up Failed per Level")]
    public GameObject[] listPopupFailed;

    public int levelAktif = 0;

    void Start()
    {
        // Pastikan masa permainan berjalan normal apabila scene dimuat
        Time.timeScale = 1f;

        // Ambil data level yang tersimpan sebelumnya menggunakan PlayerPrefs
        levelAktif = PlayerPrefs.GetInt("SavedLevelAktif", 0);
    }

    public void TampilkanPopupMenang()
    {
        for (int i = 0; i < listPopupFinish.Length; i++)
        {
            if (listPopupFinish[i] != null)
            {
                listPopupFinish[i].SetActive(i == levelAktif);
            }
        }
        Time.timeScale = 0f;
    }

    public void TampilkanPopupKalah()
    {
        for (int i = 0; i < listPopupFailed.Length; i++)
        {
            if (listPopupFailed[i] != null)
            {
                listPopupFailed[i].SetActive(i == levelAktif);
            }
        }
        Time.timeScale = 0f;
    }

    public void LanjutLevel()
    {
        Time.timeScale = 1f;
        levelAktif++; // Naikkan indeks ke level seterusnya

        // Simpan level aktif terbaru agar kekal dan tidak ter-reset
        PlayerPrefs.SetInt("SavedLevelAktif", levelAktif);
        PlayerPrefs.Save();

        // Semak sama ada masih ada level seterusnya dalam senarai
        if (levelAktif < listPopupFinish.Length)
        {
            // Muat semula scene untuk memaparkan level seterusnya
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            // Jika sudah habis semua level, reset semula ke 0 dan kembali ke Menu Utama
            PlayerPrefs.SetInt("SavedLevelAktif", 0);
            SceneManager.LoadScene("Scene_01_Welcome"); // Sesuaikan nama scene menu anda jika perlu
        }
    }

    // --- TAMBAHAN BARU UNTUK KEMBALI KE MENU & EXIT ---

    public void KembaliKeMenu()
    {
        Time.timeScale = 1f; // Kembalikan waktu normal sebelum pindah scene
        SceneManager.LoadScene("Scene_01_Welcome"); // Ganti dengan nama Scene 1 (menu utama) kamu
    }

    public void ExitGame()
    {
        Debug.Log("Keluar dari game...");
        Application.Quit();
    }
}