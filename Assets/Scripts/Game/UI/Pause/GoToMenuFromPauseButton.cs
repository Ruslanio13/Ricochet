public class GoToMenuFromPauseButton : ButtonInPause
{
    public void GoToMenu()
    {
        NormalizeTimeScale();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}