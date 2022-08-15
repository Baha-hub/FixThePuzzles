using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gpgtest : MonoBehaviour
{
    public void opengpg()
    {
        GPG_CloudSaveSystem.Instance.showUI();
    }
    public void loadit()
    {
        ActiveGame.googleLeaderBoardScore = 0;
        GPGSLeaderboards.UpdateLeaderboardScore();
    }
    public void adsDisable()
    {
        ActiveGame.adsEnabled = false;
    }
    public void adsEnable()
    {
        ActiveGame.adsEnabled = true;
    }
    public void getcoin()
    {
        ActiveGame.goldCoin += 500;
    }
}
