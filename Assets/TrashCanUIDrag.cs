using UnityEngine;
using UnityEngine.EventSystems;

public enum TrashType { Organik, Anorganik }

public class TrashCanUIDrag : MonoBehaviour, IDragHandler
{
    public TrashType type;
    RectTransform rt, canvasRect;
    Canvas canvas;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasRect = canvas.GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData e)
    {
        Vector2 p = rt.anchoredPosition;
        p.x += e.delta.x / canvas.scaleFactor;
        float batas = canvasRect.rect.width / 2 - rt.rect.width / 2;
        p.x = Mathf.Clamp(p.x, -batas, batas);
        rt.anchoredPosition = p;
    }
}
