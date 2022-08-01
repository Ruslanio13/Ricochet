using UnityEngine;
using TMPro;

public class CounterCurrentRicochets : MonoBehaviour
{
    public static CounterCurrentRicochets counterCurrentRicochets;
    [SerializeField] private TextMeshProUGUI _amountCurrentRicochetsTMPro;
    public int _amountCurrentRicochets { get; private set; } = 0;

    private void Awake()
    {
        if (counterCurrentRicochets == null)
            counterCurrentRicochets = this;
    }

    public void UpdateAmountRicochets()
    {
        _amountCurrentRicochets += 1;
        _amountCurrentRicochetsTMPro.text = "now:" + _amountCurrentRicochets.ToString();
        if (_amountCurrentRicochets > LevelLoader.levelLoader._requiredNumberOfRicochets)
            FinisherGame.finisherGame.FinishGame();
    }

    public void MakeCurrentCountNull() => _amountCurrentRicochets = 0;
}
