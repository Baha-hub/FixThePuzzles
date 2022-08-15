using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGame
{
    //tüm oyunu kontrol eden kaydeden yer.

    //--------------------------------------------------------------------
    public static List<int> starNumber=new List<int>();
    public static List<int> specialLevelsStarNumber = new List<int>();
    public static int lastPlayableLevel;
    // yukarıdaki değişkenler her level sonunda güncellenecek.
    //--------------------------------------------------------------------
    //--------------------------------------------------------------------
    public static bool musicOn;
    public static bool soundsOn;
    // müzik açılıp kapandığında güncellenecek.
    //--------------------------------------------------------------------
    //--------------------------------------------------------------------
    public static bool en;
    public static bool tr;
    // Dil değiştirildiğinde güncellenecek
    //--------------------------------------------------------------------
    //--------------------------------------------------------------------
    public static int levelSize;
    // bölüm eklendikçe elle güncelleniyor.
    //--------------------------------------------------------------------
    //--------------------------------------------------------------------
    public static int hints;
    //reklam izledikçe veya satın alındığında artacak oyun içinde kullanıldığında azalacak.
    //--------------------------------------------------------------------
    //--------------------------------------------------------------------
    public static bool tutorialOneDone;
    // tutorial yapılırsa değişecek yada tutorial'ı atla derlerse değişecek. yalnızca 1 defa yapılacak.
    //--------------------------------------------------------------------
    //--------------------------------------------------------------------
    public static int googleLeaderBoardScore;
    // google leaderboardda bulunan score.
    //-------------------------------------------------------------------
    //--------------------------------------------------------------------
    public static int secretLevelsAds;
    public static bool secretLevelsActive;
    // gizli bölümler için izlenen reklam sayısı
    //-------------------------------------------------------------------
    //--------------------------------------------------------------------
    public static bool adsEnabled;
    // reklam var mı yok mu
    //-------------------------------------------------------------------
    //--------------------------------------------------------------------
    public static bool firstOpen;
    // ilk defa telefonda açılıyorsa.
    //-------------------------------------------------------------------
    //--------------------------------------------------------------------
    public static bool haveCloudSave;
    // Cloud Save kontrol ediyor.
    //-------------------------------------------------------------------
    //--------------------------------------------------------------------
    public static int goldCoin;
    // Cloud Save kontrol ediyor.
    //-------------------------------------------------------------------
    //--------------------------------------------------------------------
    public static int ads_Amount;
    // Cloud Save kontrol ediyor.
    //-------------------------------------------------------------------
}
