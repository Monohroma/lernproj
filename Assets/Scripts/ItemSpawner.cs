using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    private Animator uiAnimator;
    [SerializeField]
    private List<Level> allLevels;
    [SerializeField]
    private int _currentLevel = 0;
    [SerializeField]
    private Bounds levelBounds;
    [SerializeField]
    private List<LevelGetter> allGetters = new List<LevelGetter>();
    [SerializeField]
    private Transform itemsOrigin;
    private List<GameObject> allPrefabs = new List<GameObject>();
    [SerializeField]
    private UnityEvent OnEndLevel;
    [SerializeField]
    private UnityEvent OnStartLevel;
    [SerializeField]
    protected PlayerScriptableModelProvider playerScriptableModelProvider;

    public int NeedCountMax => _needCountMax;
    public int NeedCountNow => _needCountNow;
    public int CurrentLevel => _currentLevel;

    private int _needCountMax = 1;
    private int _needCountNow = 0;

    private void Start()
    {
        SetupLevel(playerScriptableModelProvider.GetLvl());
        allGetters.ForEach(x => x.OnGet.AddListener(CheckLelels));
    }

    private void SetupLevel(int i)
    {
        if (i < 0 || i >= allLevels.Count)
        {
            Debug.LogError("Incorrect level id");
            return;
        }
        allPrefabs.ForEach(x => Destroy(x));
        allGetters.ForEach(x => x.DisableGetter());
        allPrefabs.Clear();
        _currentLevel = i;
        Level l = allLevels[i];
        GameObject o;
        Vector3 v;
        foreach (var item in l.objectsToSpawn)
        {
            for(int j=0;j<item.count;j++)
            {
                v = new Vector3(Random.Range(levelBounds.min.x, levelBounds.max.x), Random.Range(levelBounds.min.y, levelBounds.max.y), Random.Range(levelBounds.min.z, levelBounds.max.z));
                o = Instantiate(item.prefab, v, Quaternion.identity, itemsOrigin) as GameObject;
                allPrefabs.Add(o);
            }
        }
        _needCountMax = 0;
        foreach (var item in l.getters)
        {
            item.levelGetter.SetupGetter(item.getterColor, item.needCount, item.objectType);
            _needCountMax += item.needCount;
            _needCountNow = 0;
        }
        OnStartLevel.Invoke();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(levelBounds.center, levelBounds.size);
    }

    private void CheckLelels()
    {
        bool trig = false;
        int n = 0;
        foreach (var item in allGetters)
        {
            n += item.NeedCount;
            if (!item.IfComplite)
                trig = true;
        }
        _needCountNow = _needCountMax - n;
        if (trig)
            return;
        uiAnimator.SetTrigger("Open");
        OnEndLevel.Invoke();
    }

    public void NextLevel()
    {
        foreach (var item in allGetters)
        {
            if (!item.IfComplite)
                return;
        }
        if (_currentLevel + 1 < allLevels.Count)
            SetupLevel(_currentLevel + 1);
        else
            SetupLevel(0);
        uiAnimator.SetTrigger("Close");
    }

    public void LoadLevel(int i)
    {
        if (i < 0 || i >= allLevels.Count)
        {
            return;
        }
        SetupLevel(i);
    }
}
