using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Image progressBar;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text levelText;
    [SerializeField]
    private ItemSpawner itemSpawner;
    [SerializeField]
    private float ProgressBarLerpTiming = 0.1f;
    [SerializeField]
    private PlayerScriptableModelProvider PlayerScriptableModelProvider;
    private void Start()
    {
        UpdateScoreText();
    }
    private void Update()
    {
        if(itemSpawner.NeedCountMax != 0)
            progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, ((float)itemSpawner.NeedCountNow) / itemSpawner.NeedCountMax, ProgressBarLerpTiming);

    }

    public void SetLevelText(ItemSpawner itemSpawner)
    {
        levelText.text = "Level " + (itemSpawner.CurrentLevel + 1);
    }

    public void UpdateScoreText()
    {
        scoreText.text = PlayerScriptableModelProvider.PlayerScriptableModel.Model.Score.ToString();
    }
}
