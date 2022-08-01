using UnityEngine;

public abstract class ButtonInPause : MonoBehaviour
{
    protected void NormalizeTimeScale() => Time.timeScale = 1;
}
