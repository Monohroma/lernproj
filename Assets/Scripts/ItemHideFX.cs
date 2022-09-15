using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHideFX : MonoBehaviour
{
    [SerializeField] private VFXPoolProvider _vfxPoolProvider;

    public void Hide()
    {
        VFXPoolItem poolItem = _vfxPoolProvider.VFXPool.GetFromPool();
        poolItem.transform.position = transform.position;
        poolItem.ParticleSystem.Play();

        //Destroy(gameObject);
    }
}
