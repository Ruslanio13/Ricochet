using UnityEngine;

public class Coin : MonoBehaviour
{
    private void PickUpCoin()
    {
        BalanceManager.instance.UpgradeBalance();
        AudioPlayer.audioPlayer.CoinPickUpEffect();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            PickUpCoin();
    }
}
