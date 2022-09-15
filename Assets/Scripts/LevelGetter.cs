using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelGetter : MonoBehaviour
{
    public bool IfComplite { get { return !notblocked; } }
    public Color GetterColor => _colorDefault;
    public int NeedCount => _needCount;
    public UnityEvent OnGet;
    private Material _savedMaterial;
    [SerializeField]
    private Renderer thisRenderer;
    private int _needCount;
    private ItemType _itemType;
    private Color _colorDefault;
    private bool notblocked = false;

    private void Awake()
    {
        _savedMaterial = thisRenderer.material;
    }

    private void OnTriggerStay(Collider other)
    {
        if (notblocked)
        {
            if (other.tag == "Item")
            {
                ItemDrag itemDrag = other.GetComponent<ItemDrag>();
                if (itemDrag != null)
                {
                    if (itemDrag.onDragg)
                    {
                        if (itemDrag.whatItemType == _itemType)
                        {
                            itemDrag.SetGetter(this);
                            _savedMaterial.color = Color.green;
                        }
                        else
                        {
                            _savedMaterial.color = Color.gray;
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (notblocked)
        {
            if (other.tag == "Item")
            {
                other.GetComponent<ItemDrag>()?.SetGetter(null);
                _savedMaterial.color = _colorDefault;
            }
        }
    }

    private void AddedItem()
    {
        _needCount--;
        _savedMaterial.color = _colorDefault;
        if (_needCount<=0)
        {
            _savedMaterial.color = Color.gray;
            notblocked = false;
        }
        OnGet.Invoke();
    }

    public void SetupGetter(Color color, int needCount, ItemType itemType)
    {
        gameObject.SetActive(true);
        _savedMaterial.color = color;
        _colorDefault = color;
        _itemType = itemType;
        _needCount = needCount;
        notblocked = true;
    }

    public void DisableGetter()
    {
        notblocked = false;
        gameObject.SetActive(false);
        _needCount = 0;
    }

    public void ItemDroped(ItemDrag itemDrag)
    {
        if(itemDrag.whatItemType == _itemType)
        {
            AddedItem();
            itemDrag.HideItem();
        }
    }
}
