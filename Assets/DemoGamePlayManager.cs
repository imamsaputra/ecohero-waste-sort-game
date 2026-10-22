using System.Collections;
using UnityEngine;

public class DemoGameplayManager : MonoBehaviour
{
    public static DemoGameplayManager Instance;

    [Header("Level 1 References")]
    public GameObject level1Container;
    public GameObject bgDirtyLv1;
    public GameObject bgCleanLv1;

    [Header("Level 2 References")]
    public GameObject level2Container;
    public GameObject bgDirtyLv2;
    public GameObject bgCleanLv2;

    [Header("Level 3 References")]
    public GameObject level3Container;
    public GameObject bgDirtyLv3;
    public GameObject bgCleanLv3;

    [Header("Popups")]
    public GameObject popupFinish;
    public GameObject popupFailed;

    [Header("Settings")]
    public float delayBeforeNextLevel = 1.5f; // Jeda waktu (detik) agar background bersih kelihatan dulu

    private int currentLevel = 1;
    private int level3TrashCollected = 0; // Menghitung 2 sampah khusus di Level 3

    private void Awake()
    {
        // Setup Singleton supaya bisa dipanggil dari TrashItem.cs
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Dipanggil dari TrashItem.cs saat sampah masuk tong yang benar
    public void OnTrashSuccess()
    {
        if (currentLevel == 1)
        {
            StartCoroutine(RoutineLevel1Success());
        }
        else if (currentLevel == 2)
        {
            StartCoroutine(RoutineLevel2Success());
        }
        else if (currentLevel == 3)
        {
            level3TrashCollected++;
            // Hanya selesai jika KEDUA sampah di Level 3 sudah berhasil ditangkap
            if (level3TrashCollected >= 2)
            {
                StartCoroutine(RoutineLevel3Success());
            }
        }
    }

    // Dipanggil dari TrashItem.cs saat sampah jatuh ke LoseZone
    public void OnTrashFailed()
    {
        if (popupFailed != null)
        {
            popupFailed.SetActive(true);
        }
    }

    // Transisi Level 1 -> Level 2
    private IEnumerator RoutineLevel1Success()
    {
        if (bgDirtyLv1 != null) bgDirtyLv1.SetActive(false);
        if (bgCleanLv1 != null) bgCleanLv1.SetActive(true);

        yield return new WaitForSeconds(delayBeforeNextLevel);

        currentLevel = 2;
        if (level1Container != null) level1Container.SetActive(false);
        if (level2Container != null) level2Container.SetActive(true);
    }

    // Transisi Level 2 -> Level 3
    private IEnumerator RoutineLevel2Success()
    {
        if (bgDirtyLv2 != null) bgDirtyLv2.SetActive(false);
        if (bgCleanLv2 != null) bgCleanLv2.SetActive(true);

        yield return new WaitForSeconds(delayBeforeNextLevel);

        currentLevel = 3;
        if (level2Container != null) level2Container.SetActive(false);
        if (level3Container != null) level3Container.SetActive(true);
    }

    // Tamat (Level 3 Success)
    private IEnumerator RoutineLevel3Success()
    {
        if (bgDirtyLv3 != null) bgDirtyLv3.SetActive(false);
        if (bgCleanLv3 != null) bgCleanLv3.SetActive(true);

        yield return new WaitForSeconds(delayBeforeNextLevel);

        if (popupFinish != null) popupFinish.SetActive(true);
    }
}