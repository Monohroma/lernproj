using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public ItemType whatItemType => itemType;
    public bool onDragg => _dragging;
    [SerializeField]
    private ItemType itemType;
    [SerializeField]
    private LayerMask rayLayer;
    [SerializeField]
    private UnityEvent HideRequest;
    private bool _dragging;
    private Rigidbody _rig;
    private LevelGetter _currentGetter;
    private RaycastHit _hit;
    private void Start()
    {
        _rig = GetComponent<Rigidbody>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out _hit, 100, rayLayer))
        {
            Vector3 v = _hit.point;
            v += (Camera.main.transform.position - v).normalized * 3;
            transform.position = v;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _rig.isKinematic = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _rig.isKinematic = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _dragging = false;
        _currentGetter?.ItemDroped(this);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _dragging = true;
    }

    public void SetGetter(LevelGetter getter)
    {
        _currentGetter = getter;
    }

    public void HideItem()
    {
        HideRequest?.Invoke();
    }
}
