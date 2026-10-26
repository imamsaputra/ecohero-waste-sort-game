using UnityEngine;

public class BatasBawah : MonoBehaviour
{
    [Header("UI Popup Settings")]
    public GameObject popupFailed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Menampilkan nama objek dan tag yang menyentuh garis ke Console
        Debug.Log("Menyentuh: " + collision.gameObject.name + " | Tag: " + collision.tag);

        // Memeriksa apakah objek yang menyentuh memiliki tag "Sampah"
        if (collision.CompareTag("Sampah"))
        {
            if (popupFailed != null)
            {
                popupFailed.SetActive(true);
                Debug.Log("Popup Failed berhasil diaktifkan!");
            }
            else
            {
                Debug.LogWarning("Slot Popup Failed di Inspector kosong!");
            }
        }
        else
        {
            Debug.LogWarning("Objek menyentuh garis, tapi Tag-nya bukan 'Sampah'.");
        }
    }
}