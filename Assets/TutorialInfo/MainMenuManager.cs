using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Fungsi ini yang akan dipanggil saat tombol Level 1, 2, atau 3 diklik
    public void PilihLevel(int nomorLevel)
    {
        // Simpan data level yang dipilih
        PlayerPrefs.SetInt("SavedLevelAktif", nomorLevel);
        PlayerPrefs.Save();

        // Pindah langsung ke Scene 2 (Gameplay)
        SceneManager.LoadScene("Scene_02_WasteEncyclopedia");
    }
}