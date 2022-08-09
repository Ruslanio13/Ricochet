using UnityEngine;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader levelLoader;
    [SerializeField] private System.Collections.Generic.List<Level> _levels;
    [SerializeField] private TextMeshProUGUI _requiredNumberOfRicochetsTMPro;
    [SerializeField] private TextMeshProUGUI _currenrtNumberOfRicochetsTMPro;
    [SerializeField] private TextMeshProUGUI _currentLevelNumberTMPro;
    public int _requiredNumberOfRicochets { get; private set; }
    public Level _newLevel { get; private set; }

    private void Awake()
    {
        if (levelLoader == null)
            levelLoader = this;
    }

    private void Start()
    {
        LoadLevel();
    }

    public void LoadLevel()
    {
        int levelNumber = PlayerPrefs.GetInt("CurrentLevel", 1);
        if (levelNumber > _levels.Count)
        {
            PlayerPrefs.SetInt("CurrentLevel", 1);
            levelNumber = 1;
        }
        if (levelNumber > PlayerPrefs.GetInt("HighestLevel", 0))
            PlayerPrefs.SetInt("HighestLevel", levelNumber);
                _newLevel = _levels[levelNumber - 1];
        Instantiate(_newLevel.gameObject, Vector3.zero, Quaternion.identity);
        ArrowButton.instance.EnableButton();
        SetLevelInfo(_newLevel);
    }

    private void SetLevelInfo(Level level)
    {
        CounterCurrentRicochets.counterCurrentRicochets.MakeCurrentCountNull();
        _requiredNumberOfRicochets = level.GetAmountAimRicochet();
        _requiredNumberOfRicochetsTMPro.text = "need:" + _requiredNumberOfRicochets.ToString();
        _currenrtNumberOfRicochetsTMPro.text = "now:0";
        _currentLevelNumberTMPro.text = PlayerPrefs.GetInt("CurrentLevel", 1).ToString();
    }
}
