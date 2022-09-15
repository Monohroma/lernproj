using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableModelLoader : MonoBehaviour
{
    [SerializeField] protected List<ScriptableObject> _scriptableModelsList;

    private void Awake()
    {
        _scriptableModelsList.ForEach(x => ((IStorable)x)?.Load());
    }
}
