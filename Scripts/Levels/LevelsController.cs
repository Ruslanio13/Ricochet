using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsController : MonoBehaviour
{
    [SerializeField] private List<Button> _levelButtons = new List<Button>();
    [SerializeField] private LevelButton _levelButton;
    [SerializeField] private int _levelsAmount;

    private void Start()
    {
        CreateLevelButtons();
        NumerrateLevelButtons();
        ActivateLevelButtons();
    }

    private void CreateLevelButtons()
    {
        for (int i = 0; i < _levelsAmount; i++)
        {
            GameObject newButton = Instantiate(_levelButton.gameObject, gameObject.transform);
            _levelButtons.Add(newButton.GetComponent<Button>());
        }
    }

    private void NumerrateLevelButtons()
    {
        float fontSize = GetComponent<FlexibleGridLayout>().GetCellSize() / 2f;
        for (int i = 0; i < _levelButtons.Count; i++)
        {
            _levelButtons[i].GetComponent<LevelButton>().SetLevelNumber(i + 1, fontSize);
        }
    }

    private void ActivateLevelButtons()
    {
        PlayerPrefs.SetInt("HighestLevel", 50);
        for (int i = 0; i < PlayerPrefs.GetInt("HighestLevel", 1); i++)
        {
            _levelButtons[i].interactable = true;
        }
    }
}
