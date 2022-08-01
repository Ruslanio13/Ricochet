using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsController : MonoBehaviour
{
    [SerializeField] private List<Button> _levelButtons = new List<Button>();

    private void Start()
    {
        NumerrateLevelButtons();
        ActivateLevelButtons();
    }

    private void ActivateLevelButtons()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("HighestLevel", 1); i++)
        {
            _levelButtons[i].interactable = true;
        }
    }
    
    private void NumerrateLevelButtons()
    {
        for (int i = 0; i < _levelButtons.Count; i++)
        {
            _levelButtons[i].GetComponent<LevelButton>().SetLevelNumber(i + 1);
        }
    }
}
