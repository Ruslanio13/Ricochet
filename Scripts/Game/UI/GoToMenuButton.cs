using UnityEngine;

public class GoToMenuButton : MonoBehaviour
{
    public void GoToMenu() => UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
}