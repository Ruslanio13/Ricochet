using UnityEngine;

public class Coin : MonoBehaviour
{
    private void PickUpCoin()
    {
        BalanceManager.instance.UpgradeBalance();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickUpCoin();
    }
}
