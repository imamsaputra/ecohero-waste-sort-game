using UnityEngine;

public class TrashMove : MonoBehaviour
{
    public float speed = 800f;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        float moveInput = 0f;

        // 1. Deteksi Sentuhan Jari di HP (Android/iOS)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
            {
                moveInput = -1f; // Sentuh layar sebelah kiri -> Geser ke kiri
            }
            else
            {
                moveInput = 1f;  // Sentuh layar sebelah kanan -> Geser ke kanan
            }
        }
        // 2. Deteksi Klik Mouse (untuk uji coba di Laptop/Editor Unity)
        else if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            if (mousePos.x < Screen.width / 2)
            {
                moveInput = -1f;
            }
            else
            {
                moveInput = 1f;
            }
        }

        // Menggerakkan posisi tong sampah di Canvas
        if (moveInput != 0)
        {
            rectTransform.anchoredPosition += new Vector2(moveInput * speed * Time.deltaTime, 0);
        }
    }
}