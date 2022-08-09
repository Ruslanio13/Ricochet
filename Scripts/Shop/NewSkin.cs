using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class NewSkin : MonoBehaviour
{
    [SerializeField] protected int _price;
    [SerializeField] protected Color _color;
    [SerializeField] protected Type _typeSkin;
    [SerializeField] protected bool _isBought;
    [SerializeField] protected TextMeshProUGUI _priceTMPro;
    [SerializeField] protected TextMeshProUGUI _buySelectButtonText;
    [SerializeField] private GameObject _selectedSkinCell;
    [SerializeField] private FlexibleGridLayout _parentLayout;

    protected enum Color
    {
        RED,
        BLUE,
        GREEN,
        YELLOW,
        PINK,
        PURPLE,
        ORANGE
    }

    protected enum Type
    {
        BODY,
        TRAIL
    }

    protected void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(SetSkinInfo);
        _isBought = PlayerPrefs.GetInt("Skin" + _typeSkin.ToString() + ((int)_color).ToString(), 0) == 1;
        if (((_color == Color.RED && _typeSkin == Type.BODY) ||
            (_color == Color.YELLOW && _typeSkin == Type.TRAIL))
            && _isBought)
            BuySkin();
    }

    protected void SetSkinInfo()
    {
        _priceTMPro.text = _isBought ? "" : _price.ToString();
        ShopManager.instance.SetSelectedSkin(this);
        _buySelectButtonText.text = _isBought ? "select" : "buy";
        if (PlayerPrefs.GetInt("Skin" + _typeSkin.ToString(), _typeSkin == Type.BODY ? 0 : 3) == (int)_color)
            _buySelectButtonText.text = "selected";
        SetSelectedCellPosition();
    }

    public string GetSkinType() => _typeSkin.ToString();

    public int GetPrice() => _price;

    public int GetSkin() => (int)_color;

    public bool IsBought() => _isBought;

    public void BuySkin()
    {
        _isBought = true;
        PlayerPrefs.SetInt("Skin" + _typeSkin.ToString() + ((int)_color).ToString(), 1);
    }

    private void SetSelectedCellPosition()
    {
        _selectedSkinCell.transform.position = this.gameObject.transform.position;
        _selectedSkinCell.transform.localScale = Vector2.one * _parentLayout.GetCellSize() / 2;
    }
}
