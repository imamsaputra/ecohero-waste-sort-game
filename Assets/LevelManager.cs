using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("Tong")]
    public TrashCanUIDrag tongOrganik;
    public TrashCanUIDrag tongAnorganik;

    [Header("Sampah")]
    public RectTransform sampah;
    public Sprite spriteOrganik;
    public Sprite spriteAnorganik;
    public float speed = 400f;
    public float spawnY = 600f;
    public float bottomY = -560f;

    [Header("Background (isi 3, urut lv1 - lv3)")]
    public GameObject[] bgKotor;
    public CanvasGroup[] bgBersih;
    public float fadeDuration = 2f;

    [Header("Popup")]
    public GameObject popupLv1;
    public GameObject popupLv2;
    public GameObject popupLv3;
    public GameObject popupFinish;
    public GameObject popupFailed;

    int level = 1;
    bool playing;
    TrashType jenis;

    void Start()
    {
        SiapkanLevel();
        popupLv1.SetActive(true);   // popup lv1 tampil dulu
    }

    // Menyiapkan tampilan level (background, tong, sampah), belum mulai jatuh
    void SiapkanLevel()
    {
        StopAllCoroutines();
        playing = false;

        popupLv1.SetActive(false);
        popupLv2.SetActive(false);
        popupLv3.SetActive(false);
        popupFinish.SetActive(false);
        popupFailed.SetActive(false);

        for (int i = 0; i < 3; i++)
        {
            bool aktif = (i == level - 1);
            bgKotor[i].SetActive(aktif);
            bgBersih[i].gameObject.SetActive(aktif);
            bgBersih[i].alpha = 0f;
        }

        tongOrganik.gameObject.SetActive(level == 1 || level == 3);
        tongAnorganik.gameObject.SetActive(level == 2 || level == 3);

        if (level == 1) jenis = TrashType.Organik;
        else if (level == 2) jenis = TrashType.Anorganik;
        else jenis = Random.value < 0.5f ? TrashType.Organik : TrashType.Anorganik;

        sampah.GetComponent<Image>().sprite =
            jenis == TrashType.Organik ? spriteOrganik : spriteAnorganik;
        sampah.anchoredPosition = new Vector2(Random.Range(-600f, 600f), spawnY);
        sampah.gameObject.SetActive(true);
    }

    void Update()
    {
        if (!playing) return;

        sampah.anchoredPosition += Vector2.down * speed * Time.deltaTime;

        if (Kena(tongOrganik)) Hasil(TrashType.Organik);
        else if (Kena(tongAnorganik)) Hasil(TrashType.Anorganik);
        else if (sampah.anchoredPosition.y < bottomY) Gagal();
    }

    // Apakah pusat sampah berada di dalam area tong?
    bool Kena(TrashCanUIDrag tong)
    {
        if (!tong.gameObject.activeSelf) return false;

        Vector3[] c = new Vector3[4];
        ((RectTransform)tong.transform).GetWorldCorners(c);
        Rect r = new Rect(c[0].x, c[0].y, c[2].x - c[0].x, c[2].y - c[0].y);
        return r.Contains(sampah.position);
    }

    void Hasil(TrashType tong)
    {
        if (tong == jenis) StartCoroutine(MenangRoutine());
        else Gagal();
    }

    // Menang: background memudar jadi bersih, baru popup berikutnya muncul
    IEnumerator MenangRoutine()
    {
        playing = false;
        sampah.gameObject.SetActive(false);

        CanvasGroup bersih = bgBersih[level - 1];
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            bersih.alpha = Mathf.Clamp01(t / fadeDuration);
            yield return null;
        }
        bersih.alpha = 1f;

        level++;
        if (level > 3) popupFinish.SetActive(true);
        else if (level == 2) popupLv2.SetActive(true);
        else popupLv3.SetActive(true);
    }

    void Gagal()
    {
        playing = false;
        sampah.gameObject.SetActive(false);
        popupFailed.SetActive(true);
    }

    // ===== Fungsi untuk tombol =====

    // Tombol X di popup lv1, lv2, lv3
    public void MulaiLevel()
    {
        SiapkanLevel();
        playing = true;
    }

    // Tombol replay di popup failed
    public void Ulangi()
    {
        level = 1;
        SiapkanLevel();
        popupLv1.SetActive(true);
    }

    // Tombol Exit di popup finish dan failed
    public void KeMenu()
    {
        SceneManager.LoadScene("Scene_01_Welcome");
    }
}