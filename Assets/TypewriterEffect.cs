using System.Collections;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    [Header("Pengaturan UI")]
    public TMP_Text textComponent;

    [Header("Pengaturan Teks & Kecepatan")]
    [TextArea(3, 10)]
    public string fullText = "Selamat datang di EcoHero! Sebelum mulai bertualang memilah sampah, klik tombol di bawah ini untuk mengenal jenis-jenis sampah dulu, ya!";
    public float typingSpeed = 0.04f;

    private void Start()
    {
        if (textComponent != null)
        {
            textComponent.text = "";
            StartCoroutine(ShowTextOneByOne());
        }
    }

    IEnumerator ShowTextOneByOne()
    {
        foreach (char letter in fullText.ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}