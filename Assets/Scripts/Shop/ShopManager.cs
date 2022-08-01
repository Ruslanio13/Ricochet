using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    [SerializeField] private Button _buyOrSelectButton;
    [SerializeField] private TextMeshProUGUI _priceField;
    [SerializeField] private TextMeshProUGUI _buyOrSelectButtonText;
    [SerializeField] private Button _goMenu;
    [SerializeField] private GameObject _squareList;
    [SerializeField] private GameObject _trailList;
    [SerializeField] private GameObject _purchasingUI;
    [SerializeField] private GameObject _startWindow;
    [SerializeField] private Button _backToStartButton;
    [SerializeField] private Button _goToSquareList;
    [SerializeField] private Button _goToTrailList;
    private NewSkin _selectedSkin;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        _buyOrSelectButton.onClick.AddListener(() => { BuySkin(); SelectSkin(); });
        _goMenu.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene("Menu"));
        _backToStartButton.onClick.AddListener(BackToStartWindow);
        _goToSquareList.onClick.AddListener(ActivateSquareList);
        _goToTrailList.onClick.AddListener(ActivateTrailList);
        PlayerPrefs.SetInt("SkinBODY0", 1);
        PlayerPrefs.SetInt("SkinTRAIL3", 1);
    }

    public void SetSelectedSkin(NewSkin skin) => _selectedSkin = skin;

    private void BuySkin()
    {
        if (_priceField.text == "price" || _priceField.text == "" || _selectedSkin.IsBought() || _selectedSkin.GetPrice() > PlayerPrefs.GetInt("Balance"))
            return;
        _selectedSkin.BuySkin();
        PlayerPrefs.SetInt("Skin" + _selectedSkin.GetSkinType(), _selectedSkin.GetSkin());
        _buyOrSelectButtonText.text = "selected";
        _priceField.text = "";
        BalanceManager.instance.DowngradeBalance(_selectedSkin.GetPrice());
    }

    private void SelectSkin()
    {
        if (!_selectedSkin.IsBought())
            return;
        PlayerPrefs.SetInt("Skin" + _selectedSkin.GetSkinType(), _selectedSkin.GetSkin());
        _buyOrSelectButtonText.text = "selected";
    }

    private void BackToStartWindow()
    {
        _purchasingUI.SetActive(false);
        _squareList.SetActive(false);
        _trailList.SetActive(false);
        _startWindow.SetActive(true);
    }


    private void ActivateSquareList()
    {
        HideStartWindow();
        ActivatePurchasingUI();
        _squareList.SetActive(true);
    }

    private void ActivateTrailList()
    {
        HideStartWindow();
        ActivatePurchasingUI();
        _trailList.SetActive(true);
    }

    private void ActivatePurchasingUI() => _purchasingUI.SetActive(true);

    private void HideStartWindow() => _startWindow.SetActive(false);
}