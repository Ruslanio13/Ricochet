using UnityEngine;

public class FinisherGame : MonoBehaviour
{
    public static FinisherGame finisherGame;
    [SerializeField] private GameObject _gameOverWindow;

    private void Awake()
    {
        if (finisherGame == null)
            finisherGame = this;
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
        }
    }

    private bool CheckGameResult() => CounterCurrentRicochets.counterCurrentRicochets._amountCurrentRicochets == LevelLoader.levelLoader._requiredNumberOfRicochets;
}
