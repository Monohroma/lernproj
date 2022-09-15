using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelfDestory : MonoBehaviour
{
    public void DestroyThisItem()
    {
        Destroy(gameObject);
    }
}
