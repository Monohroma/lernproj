using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScriptableModelProvider : MonoBehaviour
{
    [SerializeField] protected PlayerScriptableModel _playerScriptableModel;

    public UnityEvent OnModuleChange;

    public PlayerScriptableModel PlayerScriptableModel => _playerScriptableModel;

    private void OnEnable()
    {
        PlayerScriptableModel.Model.OnChange.AddListener(OnModuleChangeDelegate);
    }

    private void OnDisable()
    {
        PlayerScriptableModel.Model.OnChange.RemoveListener(OnModuleChangeDelegate);
    }

    private void OnApplicationQuit()
    {
        _playerScriptableModel.Save();
    }

    public void IncreaseScore(int value)
    {
        _playerScriptableModel.AddScore(value);
    }

    public int GetLvl()
    {
        return _playerScriptableModel.Model.Lvl;
    }

    public void SetLvl(ItemSpawner itemSpawner)
    {
        _playerScriptableModel.Model.Lvl = itemSpawner.CurrentLevel;
    }

    protected void OnModuleChangeDelegate()
    {
        OnModuleChange.Invoke();
    }
}
