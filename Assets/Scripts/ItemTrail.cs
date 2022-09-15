using UnityEngine;
using UnityEngine.EventSystems;

public class ItemTrail : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private TrailRenderer _trailRenderer;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _trailRenderer.emitting = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _trailRenderer.emitting = false;
    }
}
