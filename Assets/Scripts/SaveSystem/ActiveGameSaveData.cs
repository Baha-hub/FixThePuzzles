using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActiveGameSaveData
{
// tamamen ActiveGame'in bir kopyası. save alırken tüm bilgiler buraya aktarılıyor. bu save ediliyor.
// ardından load edilirken tüm bilgiler yine buraya aktarılıyor ve buradan ActiveGame'e yazılıyor tekrar.(yazdığımız yer SaveSystem da bulunan LoadGame Metodu.)

    public List<int> starNumber;
    public List<int> specialLevelsStarNumber;
    public bool musicOn,soundsOn;
    public int levelSize;
    public int lastPlayableLevel;
    public int hints;
    public bool tutorialOneDone;
    public bool en;
    public bool tr;
    public int googleLeaderBoardScore;
    public int secretLevelsAds;
    public bool adsEnabled;
    public bool secretLevelsActive;
    public bool firstOpen;
    public bool haveCloudSave;
    public int goldCoin;
    public int ads_Amount;



    public ActiveGameSaveData(){
        starNumber=ActiveGame.starNumber;
        specialLevelsStarNumber = ActiveGame.specialLevelsStarNumber;
        musicOn =ActiveGame.musicOn;
        soundsOn=ActiveGame.soundsOn;
        levelSize=ActiveGame.levelSize;
        lastPlayableLevel=ActiveGame.lastPlayableLevel;
        hints=ActiveGame.hints;
        tutorialOneDone=ActiveGame.tutorialOneDone;
        en=ActiveGame.en;
        tr=ActiveGame.tr;
        googleLeaderBoardScore = ActiveGame.googleLeaderBoardScore;
        secretLevelsAds = ActiveGame.secretLevelsAds;
        adsEnabled = ActiveGame.adsEnabled;
        secretLevelsActive = ActiveGame.secretLevelsActive;
        firstOpen = ActiveGame.firstOpen;
        haveCloudSave = ActiveGame.haveCloudSave;
        goldCoin = ActiveGame.goldCoin;
        ads_Amount = ActiveGame.ads_Amount;
    }
}
