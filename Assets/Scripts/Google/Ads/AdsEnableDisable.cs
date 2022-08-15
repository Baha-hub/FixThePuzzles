using UnityEngine;

public class AdsEnableDisable : MonoBehaviour
{
    public void adsDisable()
    {
        ActiveGame.adsEnabled = false;
    }
    public void adsEnable()
    {
        ActiveGame.adsEnabled = true;
    }
}
