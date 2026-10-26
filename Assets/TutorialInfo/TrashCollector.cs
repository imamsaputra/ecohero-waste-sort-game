using UnityEngine;

public class TrashCollector : MonoBehaviour
{
    public GameObject popupFinish;
    public GameObject popupFailed;
    public float jarakBerhasil = 150f;
    private Transform sampahTransform;

    void Start()
    {
        if (popupFinish != null) popupFinish.SetActive(false);
        if (popupFailed != null) popupFailed.SetActive(false);

        GameObject sampahObj = GameObject.FindWithTag("Sampah");
        if (sampahObj != null)
        {
            sampahTransform = sampahObj.transform;
        }
    }

    void Update()
    {
        if (sampahTransform != null)
        {
            float jarak = Vector2.Distance(transform.position, sampahTransform.position);
            if (jarak < jarakBerhasil)
            {
                if (popupFinish != null) popupFinish.SetActive(true);
                Destroy(sampahTransform.gameObject);
                enabled = false;
            }
        }
    }
}