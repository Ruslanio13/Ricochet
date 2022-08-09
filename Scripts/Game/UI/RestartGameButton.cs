using UnityEngine;

public class RestartGameButton : MonoBehaviour
{
    public void RestartGame() => UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
}