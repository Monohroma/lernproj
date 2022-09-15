using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXResetPool : MonoBehaviour
{
    [SerializeField] private VFXPool _vfxPool;

    private void OnDisable()
    {
        _vfxPool.ResetPool();
    }
}
