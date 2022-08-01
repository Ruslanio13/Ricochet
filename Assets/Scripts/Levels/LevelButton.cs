using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelButton : MonoBehaviour
{
    private int _levelNumber;
    [SerializeField] private TextMeshProUGUI _levelNumberTMPro;

    public void SetLevelNumber (int levelNumber)
    {
        _levelNumber = levelNumber;
        _levelNumberTMPro.text = _levelNumber.ToString();
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
