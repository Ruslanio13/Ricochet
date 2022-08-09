using UnityEngine;
using TMPro;

public class FinisherGame : MonoBehaviour
{
    public static FinisherGame finisherGame;
    [SerializeField] private GameObject _gameOverWindow;
    [SerializeField] private TextMeshProUGUI _fps;

    private void Awake()
    {
        if (finisherGame == null)
            finisherGame = this;
    }

    private void Update()
    {
        _fps.text = (1.0f / Time.deltaTime).ToString();
    }

    public void FinishGame()
    {
        bool isWininng = CheckGameResult();
        LevelLoader.levelLoader._newLevel.GetPlayer().StopPlayer();

        if (isWininng)
        {
            StartCoroutine(LevelLoader.levelLoader._newLevel.SmoothTransition());
            PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel", 1) + 1);
        }
        else
        {
            _gameOverWindow.SetActive(true);
           // ADS.adsManager.ShowAds();
        }
    }

    private bool CheckGameResult() => CounterCurrentRicochets.counterCurrentRicochets._amountCurrentRicochets == LevelLoader.levelLoader._requiredNumberOfRicochets;
}
