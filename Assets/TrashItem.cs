using UnityEngine;

public class TrashItem : MonoBehaviour
{
    private bool isHandled = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isHandled) return;

        // Jika menyentuh tong sampah yang benar
        if (other.CompareTag("TrashCan"))
        {
            isHandled = true;
            DemoGameplayManager.Instance.OnTrashSuccess(); // Panggil transisi level / bersih background
            Destroy(gameObject); // Hapus sampah yang berhasil ditangkap
        }
        // Jika jatuh meleset sampai ke bawah layar
        else if (other.CompareTag("LoseZone"))
        {
            isHandled = true;
            DemoGameplayManager.Instance.OnTrashFailed(); // Panggil Popup Failed
            Destroy(gameObject); // Hapus sampah yang jatuh
        }
    }
}