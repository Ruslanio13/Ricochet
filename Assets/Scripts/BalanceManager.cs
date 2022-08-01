using UnityEngine;
using TMPro;

public class BalanceManager : MonoBehaviour
{
    public static BalanceManager instance;
    [SerializeField] private TextMeshProUGUI _balanceTmpro;
    private int _balance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        _balance = PlayerPrefs.GetInt("Balance", 0);
        _balanceTmpro.text = _balance.ToString();
    }

    public void UpgradeBalance()
    {
        _balance += 1;
        PlayerPrefs.SetInt("Balance", _balance);
        UpdateBalance();
    }

    public void DowngradeBalance(int price)
    {
        _balance -= price;
        PlayerPrefs.SetInt("Balance", _balance);
        UpdateBalance();
    }

    private void UpdateBalance()
    {
        _balanceTmpro.text = _balance.ToString();
    }

}
