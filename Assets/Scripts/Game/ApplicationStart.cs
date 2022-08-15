using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ApplicationStart : MonoBehaviour
{
    public Text hintsAmount;
    //################## Secret levels
    public GameObject secretLevelsLock;
    public Text secretLeveltext, secretLevelNeedAdAmount,goldAmountText;
    //################## Secret levels
    // Language kodunu burada alıyoruz
    public LanguageScripts languageScripts;


    //program ilk açıldığında 1 defa load yapıyor. ve GetDone metodunu kullanıyor. Ayrıca LevelSize'ı güncelliyor.
    void Start()
    {
        SaveSystem.Load();
        GPGSLeaderboardScore();
    }
    void Update()
    {
        goldAmountText.text = ActiveGame.goldCoin.ToString();
        hintsAmount.text = ActiveGame.hints.ToString();
        secretLevelNeedAdAmount.text = (20 - ActiveGame.secretLevelsAds).ToString();
        languageScripts.MainMenuLevelsLanguage();
        EnableSecretLevelsChecker();
        HintAmountChecker();
    }

    
    private void GPGSLeaderboardScore()
    {
        ActiveGame.googleLeaderBoardScore = 0;
        for (int i = 0; i < ActiveGame.starNumber.Count; i++)
        {
            ActiveGame.googleLeaderBoardScore += ActiveGame.starNumber[i];
        }
        for (int i = 0; i < ActiveGame.specialLevelsStarNumber.Count; i++)
        {
            ActiveGame.googleLeaderBoardScore += ActiveGame.specialLevelsStarNumber[i];
        }
        GPGSLeaderboards.UpdateLeaderboardScore();
    }
    private void EnableSecretLevelsChecker()
    {
        if (ActiveGame.secretLevelsAds >= 20)
        {
            ActiveGame.secretLevelsActive = true;
        }
        if (ActiveGame.secretLevelsActive == true)
        {
            secretLeveltext.text = "";
            secretLevelNeedAdAmount.text = "";
            secretLevelsLock.SetActive(false);
        }
    }
    private void HintAmountChecker()
    {
        if (ActiveGame.hints > 9)
        {
            ActiveGame.hints = 9;
        }
    }
}