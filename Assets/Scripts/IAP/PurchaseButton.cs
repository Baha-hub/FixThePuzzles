using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseButton : MonoBehaviour
{
    public enum PurchaseType {noAds, getHints, openLevels, pro };
    public PurchaseType purchaseType;
    public void ClickPurchaseButton()
    {
        switch (purchaseType)
        {
            case PurchaseType.noAds:
                IAPManager.instance.FiveHundred();
                break;
            case PurchaseType.getHints:
                IAPManager.instance.OneTousendFiveHundred();
                break;
            case PurchaseType.pro:
                IAPManager.instance.FourTousend();
                break;
            case PurchaseType.openLevels:
                IAPManager.instance.FiveTousend();
                break;
        }
    }
}
