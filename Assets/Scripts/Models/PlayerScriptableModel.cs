using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptableModel", menuName = "Create PlayerScriptableModel", order = 1)]
public class PlayerScriptableModel : ScriptableModel<PlayerModel>
{
    public bool AddScore(int v)
    {
        if (Model.Score + v < 0)
            return false;
        Model.Score += v;
        return true;
    }
}
