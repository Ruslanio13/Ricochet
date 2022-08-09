using UnityEngine;

public class ADS : MonoBehaviour
{
    public static ADS adsManager;

    public void ShowAds()
    {
        Application.ExternalCall("ShowAds");
    }
}
