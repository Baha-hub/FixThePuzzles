using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAdsAuto : MonoBehaviour
{
    public ADManager aDManager;
    void Update()
    {
        if (ActiveGame.ads_Amount % 6 == 5)
        {
            ActiveGame.ads_Amount++;
            aDManager.Display_InterstitialAD();
        }
    }
}