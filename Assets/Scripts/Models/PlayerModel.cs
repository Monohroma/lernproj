using UnityEngine;

[System.Serializable]
public class PlayerModel : Model
{
    [SerializeField] protected string _playerName;
    [SerializeField] protected int _score;
    [SerializeField] protected int _lvl;

    public string PlayerName
    {
        get => _playerName;
        set => SetData(ref _playerName, value);
    }

    public int Score
    {
        get => _score;
        set
        {
            if (value < 0)
            {
                SetData(ref _score, 0);
                return;
            }
            SetData(ref _score, value);
        }
    }

    public int Lvl
    {
        get => _lvl;
        set => SetData(ref _lvl, value);
    }
}
