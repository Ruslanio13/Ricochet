using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelButton : MonoBehaviour
{
    private int _levelNumber;
    [SerializeField] private TextMeshProUGUI _levelNumberTMPro;
    [SerializeField] private RectTransform _myRectTransform;

    public void SetLevelNumber (int levelNumber, float fontSize)
    {
        _levelNumber = levelNumber;
        _levelNumberTMPro.text = _levelNumber.ToString();
        _levelNumberTMPro.fontSize = fontSize;
    }

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(GoToSelecetedLevel);
    }

    private void GoToSelecetedLevel()
    {
        PlayerPrefs.SetInt("CurrentLevel", _levelNumber);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
