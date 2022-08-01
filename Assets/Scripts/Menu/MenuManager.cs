using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button _gameButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _goToLevelsButton;
    [SerializeField] private Button _showReferenceButton;
    [SerializeField] private Button _hideReferenceButton;
    [SerializeField] private GameObject _canvasReference;

    private void Start()
    {
        _gameButton.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene("Game"));
        _shopButton.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene("Shop"));
        _goToLevelsButton.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene("Levels"));
        _showReferenceButton.onClick.AddListener(() => _canvasReference.SetActive(true));
        _hideReferenceButton.onClick.AddListener(() => _canvasReference.SetActive(false));
    }
}
