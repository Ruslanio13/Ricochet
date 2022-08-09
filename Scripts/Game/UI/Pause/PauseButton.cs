using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject _pauseCanvas;

    public void GoToPause()
    {
        StopTime();
        ActivatePauseCanvas();
    }

    private void StopTime() => Time.timeScale = 0;

    private void ActivatePauseCanvas() => _pauseCanvas.SetActive(true);
}
