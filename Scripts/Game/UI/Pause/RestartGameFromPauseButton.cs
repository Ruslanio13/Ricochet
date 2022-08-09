public class RestartGameFromPauseButton : ButtonInPause
{
    public void RestartGame()
    {
        NormalizeTimeScale();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}