using UnityEngine;
using UnityEngine.EventSystems; // Wajib untuk deteksi sentuhan/drag UI

public class TrashCanUIDrag : MonoBehaviour, IDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        // Mencari Canvas induk dari tong sampah
        canvas = GetComponentInParent<Canvas>();
    }

    // Fungsi ini otomatis berjalan saat tong sampah diseret/didrag
    public void OnDrag(PointerEventData eventData)
    {
        if (canvas == null) return;

        // Mengubah gerak mouse/sentuhan menjadi pergerakan posisi tong sampah
        Vector2 currentPos = rectTransform.anchoredPosition;
        currentPos.x += eventData.delta.x / canvas.scaleFactor; // Hanya mengubah posisi X (kanan-kiri)

        rectTransform.anchoredPosition = currentPos;
    }
}