using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BuyButtons : MonoBehaviour
{
    public void GetHints()
    {
        if (ActiveGame.hints<9 && ActiveGame.goldCoin>=300)
        {
            ActiveGame.hints = 9;
            ActiveGame.goldCoin -= 300;
            SaveSystem.Save();
        }
    }
    public void GetNoAds()
    {
        if (ActiveGame.adsEnabled==true && ActiveGame.goldCoin >= 900)
        {
            ActiveGame.adsEnabled=false;
            ActiveGame.goldCoin -= 900;
            SaveSystem.Save();
        }
    }
    public void GetSpecialLevels()
    {
        if (ActiveGame.secretLevelsActive==false && ActiveGame.goldCoin >= 2000)
        {
            ActiveGame.secretLevelsActive=true;
            ActiveGame.goldCoin -= 2000;
            SaveSystem.Save();
        }
    }
    public void GetPro()
    {
        if (ActiveGame.secretLevelsActive == false && ActiveGame.goldCoin >= 2900)
        {
            ActiveGame.secretLevelsActive = true;
            SaveSystem.Save();
        }
        if (ActiveGame.adsEnabled == true)
        {
            ActiveGame.adsEnabled = false;
            SaveSystem.Save();
        }
        if (ActiveGame.hints < 9)
        {
            ActiveGame.hints = 9;
            SaveSystem.Save();
        }
        ActiveGame.goldCoin -= 2900;
    }
}
