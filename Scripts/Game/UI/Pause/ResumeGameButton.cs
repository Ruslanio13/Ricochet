using UnityEngine;

public class ResumeGameButton : ButtonInPause
{
    [SerializeField] private GameObject _pauseCanvas;

    public void ResumeGame()
    {
        NormalizeTimeScale();
        SwitchOffPauseCanvas();
    }

    private void SwitchOffPauseCanvas() => _pauseCanvas.SetActive(false);
}
