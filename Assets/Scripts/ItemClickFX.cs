using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemClickFX : MonoBehaviour
{
    //[SerializeField] private VFXPoolProvider _vfxPoolProvider;
    public UnityEvent OnClick;
    private void OnMouseDown()
    {
        /*VFXPoolItem poolItem = _vfxPoolProvider.VFXPool.GetFromPool();
        poolItem.transform.position = transform.position;
        poolItem.ParticleSystem.Play();*/

        OnClick.Invoke();
    }
}
