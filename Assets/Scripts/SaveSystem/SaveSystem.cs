using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveSystem
{
    public static ActiveGameSaveData data;
    public static string path = Application.persistentDataPath + "/player.save";

    // ActiveGame i activeGameSaveData adında kaydediyor.
    public static void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(path, FileMode.Create);

        ActiveGameSaveData activeGameSaveData = new ActiveGameSaveData();

        formatter.Serialize(stream, activeGameSaveData);
        stream.Close();
        if (!(Application.internetReachability == NetworkReachability.NotReachable)&& Social.Active.localUser.authenticated)
            SaveGoogle();
    }

    // Öncelikle GetReady metodu çalışıyor.
    // sonra save dosyası var mı yok mu bakılıyor. eğer varsa if yapısına girerek save'i datanın içine yazıyor.
    // ardından LoadGame metodunu çağırıyor.
    // eğer save yoksa else yapısına girerek default hazırlanmış olan save i load ediyor.
    public static ActiveGameSaveData Load()
    {
        GetReady();
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data = formatter.Deserialize(stream) as ActiveGameSaveData;
            stream.Close();
            LoadGame();
        }
        else
        {
            Debug.Log("Save File Not Found...");
            Debug.Log("Default Save Loading...");
            DefaultLoadGame();
        }
        return data;
    }

    // bu metoda sadece save varsa gelebiliyor. load edilen save'i ActiveGame'e aktarıyor. (dataya gelen değerleri oraya yazıyor.)
    public static void LoadGame()
    {
        ActiveGame.starNumber = SaveSystem.data.starNumber;
        ActiveGame.specialLevelsStarNumber = SaveSystem.data.specialLevelsStarNumber;
        ActiveGame.musicOn = SaveSystem.data.musicOn;
        ActiveGame.soundsOn = SaveSystem.data.soundsOn;
        ActiveGame.levelSize = SaveSystem.data.levelSize;
        ActiveGame.lastPlayableLevel = SaveSystem.data.lastPlayableLevel;
        ActiveGame.hints = SaveSystem.data.hints;
        ActiveGame.tutorialOneDone = SaveSystem.data.tutorialOneDone;
        ActiveGame.en = SaveSystem.data.en;
        ActiveGame.tr = SaveSystem.data.tr;
        ActiveGame.googleLeaderBoardScore = SaveSystem.data.googleLeaderBoardScore;
        ActiveGame.secretLevelsAds = SaveSystem.data.secretLevelsAds;
        ActiveGame.adsEnabled = SaveSystem.data.adsEnabled;
        ActiveGame.secretLevelsActive = SaveSystem.data.secretLevelsActive;
        ActiveGame.firstOpen = SaveSystem.data.firstOpen;
        ActiveGame.haveCloudSave = SaveSystem.data.haveCloudSave;
        ActiveGame.goldCoin = SaveSystem.data.goldCoin;
        ActiveGame.ads_Amount = 0;
    }

    // eğer bir save dosyası yoksa burası çalışıyor ve standart başlangıç değerlerini load ediyor ActiveGame'e
    public static void DefaultLoadGame()
    {
        ActiveGame.starNumber[0] = 0;
        ActiveGame.specialLevelsStarNumber[0] = 0;
        ActiveGame.musicOn = true;
        ActiveGame.soundsOn = true;
        ActiveGame.levelSize = 48;
        ActiveGame.lastPlayableLevel = 1;
        ActiveGame.hints = 0;
        ActiveGame.tutorialOneDone = false;
        ActiveGame.en = true;
        ActiveGame.tr = false;
        ActiveGame.googleLeaderBoardScore = 0;
        ActiveGame.secretLevelsAds = 0;
        ActiveGame.adsEnabled = true;
        ActiveGame.secretLevelsActive = false;
        ActiveGame.firstOpen = true;
        ActiveGame.haveCloudSave = false;
        ActiveGame.goldCoin = 0;
        ActiveGame.ads_Amount = 0;
    }

    // oyundaki level sayısı kadar ActiveGame de gerekli olan listeleri genişletiyor.(bu olmadan nullpointer alınır listenin eleman sayıları 0 görünür.)
    public static void GetReady()
    {
        for (int i = 0; i < 48; i++)
        {
            ActiveGame.starNumber.Add(0);
        }
        for (int i = 0; i<24;i++)
        {
            ActiveGame.specialLevelsStarNumber.Add(0);
        }
    }
    public static void SaveGoogle()
    {
        ActiveGame.haveCloudSave = true;
        if (ActiveGame.lastPlayableLevel < 10)
        {
            if (ActiveGame.adsEnabled==true)
            {
                if (ActiveGame.secretLevelsActive==true)
                {
                    GPG_CloudSaveSystem.Instance.saveString = "0" + ActiveGame.lastPlayableLevel.ToString() + ActiveGame.hints.ToString()
                                                + ActiveGame.starNumber[0] + ActiveGame.starNumber[1] + ActiveGame.starNumber[2]
                                                + ActiveGame.starNumber[3] + ActiveGame.starNumber[4] + ActiveGame.starNumber[5]
                                                + ActiveGame.starNumber[6] + ActiveGame.starNumber[7] + ActiveGame.starNumber[8]
                                                + ActiveGame.starNumber[9] + ActiveGame.starNumber[10] + ActiveGame.starNumber[11]
                                                + ActiveGame.starNumber[12] + ActiveGame.starNumber[13] + ActiveGame.starNumber[14]
                                                + ActiveGame.starNumber[15] + ActiveGame.starNumber[16] + ActiveGame.starNumber[17]
                                                + ActiveGame.starNumber[18] + ActiveGame.starNumber[19] + ActiveGame.starNumber[20]
                                                + ActiveGame.starNumber[21] + ActiveGame.starNumber[22] + ActiveGame.starNumber[23]
                                                + ActiveGame.starNumber[24] + ActiveGame.starNumber[25] + ActiveGame.starNumber[26]
                                                + ActiveGame.starNumber[27] + ActiveGame.starNumber[28] + ActiveGame.starNumber[29]
                                                + ActiveGame.starNumber[30] + ActiveGame.starNumber[31] + ActiveGame.starNumber[32]
                                                + ActiveGame.starNumber[33] + ActiveGame.starNumber[34] + ActiveGame.starNumber[35]
                                                + ActiveGame.starNumber[36] + ActiveGame.starNumber[37] + ActiveGame.starNumber[38]
                                                + ActiveGame.starNumber[39] + ActiveGame.starNumber[40] + ActiveGame.starNumber[41]
                                                + ActiveGame.starNumber[42] + ActiveGame.starNumber[43] + ActiveGame.starNumber[44]
                                                + ActiveGame.starNumber[45] + ActiveGame.starNumber[46] + ActiveGame.starNumber[47]
                                                + "1"                      + "1"
                                                + ActiveGame.specialLevelsStarNumber[0] + ActiveGame.specialLevelsStarNumber[1]
                                                + ActiveGame.specialLevelsStarNumber[2] + ActiveGame.specialLevelsStarNumber[3]
                                                + ActiveGame.specialLevelsStarNumber[4] + ActiveGame.specialLevelsStarNumber[5]
                                                + ActiveGame.specialLevelsStarNumber[6] + ActiveGame.specialLevelsStarNumber[7]
                                                + ActiveGame.specialLevelsStarNumber[8] + ActiveGame.specialLevelsStarNumber[9]
                                                + ActiveGame.specialLevelsStarNumber[10] + ActiveGame.specialLevelsStarNumber[11]
                                                + ActiveGame.specialLevelsStarNumber[12] + ActiveGame.specialLevelsStarNumber[13]
                                                + ActiveGame.specialLevelsStarNumber[14] + ActiveGame.specialLevelsStarNumber[15]
                                                + ActiveGame.specialLevelsStarNumber[16] + ActiveGame.specialLevelsStarNumber[17]
                                                + ActiveGame.specialLevelsStarNumber[18] + ActiveGame.specialLevelsStarNumber[19]
                                                + ActiveGame.specialLevelsStarNumber[20] + ActiveGame.specialLevelsStarNumber[21]
                                                + ActiveGame.specialLevelsStarNumber[22] + ActiveGame.specialLevelsStarNumber[23];
                }
                else
                {
                    GPG_CloudSaveSystem.Instance.saveString = "0" + ActiveGame.lastPlayableLevel.ToString() + ActiveGame.hints.ToString()
                                                + ActiveGame.starNumber[0] + ActiveGame.starNumber[1] + ActiveGame.starNumber[2]
                                                + ActiveGame.starNumber[3] + ActiveGame.starNumber[4] + ActiveGame.starNumber[5]
                                                + ActiveGame.starNumber[6] + ActiveGame.starNumber[7] + ActiveGame.starNumber[8]
                                                + ActiveGame.starNumber[9] + ActiveGame.starNumber[10] + ActiveGame.starNumber[11]
                                                + ActiveGame.starNumber[12] + ActiveGame.starNumber[13] + ActiveGame.starNumber[14]
                                                + ActiveGame.starNumber[15] + ActiveGame.starNumber[16] + ActiveGame.starNumber[17]
                                                + ActiveGame.starNumber[18] + ActiveGame.starNumber[19] + ActiveGame.starNumber[20]
                                                + ActiveGame.starNumber[21] + ActiveGame.starNumber[22] + ActiveGame.starNumber[23]
                                                + ActiveGame.starNumber[24] + ActiveGame.starNumber[25] + ActiveGame.starNumber[26]
                                                + ActiveGame.starNumber[27] + ActiveGame.starNumber[28] + ActiveGame.starNumber[29]
                                                + ActiveGame.starNumber[30] + ActiveGame.starNumber[31] + ActiveGame.starNumber[32]
                                                + ActiveGame.starNumber[33] + ActiveGame.starNumber[34] + ActiveGame.starNumber[35]
                                                + ActiveGame.starNumber[36] + ActiveGame.starNumber[37] + ActiveGame.starNumber[38]
                                                + ActiveGame.starNumber[39] + ActiveGame.starNumber[40] + ActiveGame.starNumber[41]
                                                + ActiveGame.starNumber[42] + ActiveGame.starNumber[43] + ActiveGame.starNumber[44]
                                                + ActiveGame.starNumber[45] + ActiveGame.starNumber[46] + ActiveGame.starNumber[47]
                                                + "0"                      + "1"
                                                + ActiveGame.specialLevelsStarNumber[0] + ActiveGame.specialLevelsStarNumber[1]
                                                + ActiveGame.specialLevelsStarNumber[2] + ActiveGame.specialLevelsStarNumber[3]
                                                + ActiveGame.specialLevelsStarNumber[4] + ActiveGame.specialLevelsStarNumber[5]
                                                + ActiveGame.specialLevelsStarNumber[6] + ActiveGame.specialLevelsStarNumber[7]
                                                + ActiveGame.specialLevelsStarNumber[8] + ActiveGame.specialLevelsStarNumber[9]
                                                + ActiveGame.specialLevelsStarNumber[10] + ActiveGame.specialLevelsStarNumber[11]
                                                + ActiveGame.specialLevelsStarNumber[12] + ActiveGame.specialLevelsStarNumber[13]
                                                + ActiveGame.specialLevelsStarNumber[14] + ActiveGame.specialLevelsStarNumber[15]
                                                + ActiveGame.specialLevelsStarNumber[16] + ActiveGame.specialLevelsStarNumber[17]
                                                + ActiveGame.specialLevelsStarNumber[18] + ActiveGame.specialLevelsStarNumber[19]
                                                + ActiveGame.specialLevelsStarNumber[20] + ActiveGame.specialLevelsStarNumber[21]
                                                + ActiveGame.specialLevelsStarNumber[22] + ActiveGame.specialLevelsStarNumber[23];
                }
            }
            else
            {
                if (ActiveGame.secretLevelsActive == true)
                {
                    GPG_CloudSaveSystem.Instance.saveString = "0" + ActiveGame.lastPlayableLevel.ToString() + ActiveGame.hints.ToString()
                                                + ActiveGame.starNumber[0] + ActiveGame.starNumber[1] + ActiveGame.starNumber[2]
                                                + ActiveGame.starNumber[3] + ActiveGame.starNumber[4] + ActiveGame.starNumber[5]
                                                + ActiveGame.starNumber[6] + ActiveGame.starNumber[7] + ActiveGame.starNumber[8]
                                                + ActiveGame.starNumber[9] + ActiveGame.starNumber[10] + ActiveGame.starNumber[11]
                                                + ActiveGame.starNumber[12] + ActiveGame.starNumber[13] + ActiveGame.starNumber[14]
                                                + ActiveGame.starNumber[15] + ActiveGame.starNumber[16] + ActiveGame.starNumber[17]
                                                + ActiveGame.starNumber[18] + ActiveGame.starNumber[19] + ActiveGame.starNumber[20]
                                                + ActiveGame.starNumber[21] + ActiveGame.starNumber[22] + ActiveGame.starNumber[23]
                                                + ActiveGame.starNumber[24] + ActiveGame.starNumber[25] + ActiveGame.starNumber[26]
                                                + ActiveGame.starNumber[27] + ActiveGame.starNumber[28] + ActiveGame.starNumber[29]
                                                + ActiveGame.starNumber[30] + ActiveGame.starNumber[31] + ActiveGame.starNumber[32]
                                                + ActiveGame.starNumber[33] + ActiveGame.starNumber[34] + ActiveGame.starNumber[35]
                                                + ActiveGame.starNumber[36] + ActiveGame.starNumber[37] + ActiveGame.starNumber[38]
                                                + ActiveGame.starNumber[39] + ActiveGame.starNumber[40] + ActiveGame.starNumber[41]
                                                + ActiveGame.starNumber[42] + ActiveGame.starNumber[43] + ActiveGame.starNumber[44]
                                                + ActiveGame.starNumber[45] + ActiveGame.starNumber[46] + ActiveGame.starNumber[47]
                                                + "1"                      + "0"
                                                + ActiveGame.specialLevelsStarNumber[0] + ActiveGame.specialLevelsStarNumber[1]
                                                + ActiveGame.specialLevelsStarNumber[2] + ActiveGame.specialLevelsStarNumber[3]
                                                + ActiveGame.specialLevelsStarNumber[4] + ActiveGame.specialLevelsStarNumber[5]
                                                + ActiveGame.specialLevelsStarNumber[6] + ActiveGame.specialLevelsStarNumber[7]
                                                + ActiveGame.specialLevelsStarNumber[8] + ActiveGame.specialLevelsStarNumber[9]
                                                + ActiveGame.specialLevelsStarNumber[10] + ActiveGame.specialLevelsStarNumber[11]
                                                + ActiveGame.specialLevelsStarNumber[12] + ActiveGame.specialLevelsStarNumber[13]
                                                + ActiveGame.specialLevelsStarNumber[14] + ActiveGame.specialLevelsStarNumber[15]
                                                + ActiveGame.specialLevelsStarNumber[16] + ActiveGame.specialLevelsStarNumber[17]
                                                + ActiveGame.specialLevelsStarNumber[18] + ActiveGame.specialLevelsStarNumber[19]
                                                + ActiveGame.specialLevelsStarNumber[20] + ActiveGame.specialLevelsStarNumber[21]
                                                + ActiveGame.specialLevelsStarNumber[22] + ActiveGame.specialLevelsStarNumber[23];
                }
                else
                {
                    GPG_CloudSaveSystem.Instance.saveString = "0" + ActiveGame.lastPlayableLevel.ToString() + ActiveGame.hints.ToString()
                                                + ActiveGame.starNumber[0] + ActiveGame.starNumber[1] + ActiveGame.starNumber[2]
                                                + ActiveGame.starNumber[3] + ActiveGame.starNumber[4] + ActiveGame.starNumber[5]
                                                + ActiveGame.starNumber[6] + ActiveGame.starNumber[7] + ActiveGame.starNumber[8]
                                                + ActiveGame.starNumber[9] + ActiveGame.starNumber[10] + ActiveGame.starNumber[11]
                                                + ActiveGame.starNumber[12] + ActiveGame.starNumber[13] + ActiveGame.starNumber[14]
                                                + ActiveGame.starNumber[15] + ActiveGame.starNumber[16] + ActiveGame.starNumber[17]
                                                + ActiveGame.starNumber[18] + ActiveGame.starNumber[19] + ActiveGame.starNumber[20]
                                                + ActiveGame.starNumber[21] + ActiveGame.starNumber[22] + ActiveGame.starNumber[23]
                                                + ActiveGame.starNumber[24] + ActiveGame.starNumber[25] + ActiveGame.starNumber[26]
                                                + ActiveGame.starNumber[27] + ActiveGame.starNumber[28] + ActiveGame.starNumber[29]
                                                + ActiveGame.starNumber[30] + ActiveGame.starNumber[31] + ActiveGame.starNumber[32]
                                                + ActiveGame.starNumber[33] + ActiveGame.starNumber[34] + ActiveGame.starNumber[35]
                                                + ActiveGame.starNumber[36] + ActiveGame.starNumber[37] + ActiveGame.starNumber[38]
                                                + ActiveGame.starNumber[39] + ActiveGame.starNumber[40] + ActiveGame.starNumber[41]
                                                + ActiveGame.starNumber[42] + ActiveGame.starNumber[43] + ActiveGame.starNumber[44]
                                                + ActiveGame.starNumber[45] + ActiveGame.starNumber[46] + ActiveGame.starNumber[47]
                                                + "0"                      + "0"
                                                + ActiveGame.specialLevelsStarNumber[0] + ActiveGame.specialLevelsStarNumber[1]
                                                + ActiveGame.specialLevelsStarNumber[2] + ActiveGame.specialLevelsStarNumber[3]
                                                + ActiveGame.specialLevelsStarNumber[4] + ActiveGame.specialLevelsStarNumber[5]
                                                + ActiveGame.specialLevelsStarNumber[6] + ActiveGame.specialLevelsStarNumber[7]
                                                + ActiveGame.specialLevelsStarNumber[8] + ActiveGame.specialLevelsStarNumber[9]
                                                + ActiveGame.specialLevelsStarNumber[10] + ActiveGame.specialLevelsStarNumber[11]
                                                + ActiveGame.specialLevelsStarNumber[12] + ActiveGame.specialLevelsStarNumber[13]
                                                + ActiveGame.specialLevelsStarNumber[14] + ActiveGame.specialLevelsStarNumber[15]
                                                + ActiveGame.specialLevelsStarNumber[16] + ActiveGame.specialLevelsStarNumber[17]
                                                + ActiveGame.specialLevelsStarNumber[18] + ActiveGame.specialLevelsStarNumber[19]
                                                + ActiveGame.specialLevelsStarNumber[20] + ActiveGame.specialLevelsStarNumber[21]
                                                + ActiveGame.specialLevelsStarNumber[22] + ActiveGame.specialLevelsStarNumber[23];
                }
            }
            if (ActiveGame.goldCoin == 0)
            {
                GPG_CloudSaveSystem.Instance.saveString += "0" + "0" + "0" + "0";
            }
            else if (ActiveGame.goldCoin < 100)
            {
                GPG_CloudSaveSystem.Instance.saveString += "0" + "0" + ActiveGame.goldCoin;
            }
            else if (ActiveGame.goldCoin >= 100 && ActiveGame.goldCoin < 1000)
            {
                GPG_CloudSaveSystem.Instance.saveString += "0" + ActiveGame.goldCoin;
            }
            else if (ActiveGame.goldCoin >= 1000)
            {
                GPG_CloudSaveSystem.Instance.saveString += ActiveGame.goldCoin+"";
            }

            GPG_CloudSaveSystem.Instance.SaveToCloud();
        }
        else
        {
            if (ActiveGame.adsEnabled == true)
            {
                if (ActiveGame.secretLevelsActive == true)
                {
                    GPG_CloudSaveSystem.Instance.saveString = ActiveGame.lastPlayableLevel.ToString() + ActiveGame.hints.ToString()
                                                + ActiveGame.starNumber[0] + ActiveGame.starNumber[1] + ActiveGame.starNumber[2]
                                                + ActiveGame.starNumber[3] + ActiveGame.starNumber[4] + ActiveGame.starNumber[5]
                                                + ActiveGame.starNumber[6] + ActiveGame.starNumber[7] + ActiveGame.starNumber[8]
                                                + ActiveGame.starNumber[9] + ActiveGame.starNumber[10] + ActiveGame.starNumber[11]
                                                + ActiveGame.starNumber[12] + ActiveGame.starNumber[13] + ActiveGame.starNumber[14]
                                                + ActiveGame.starNumber[15] + ActiveGame.starNumber[16] + ActiveGame.starNumber[17]
                                                + ActiveGame.starNumber[18] + ActiveGame.starNumber[19] + ActiveGame.starNumber[20]
                                                + ActiveGame.starNumber[21] + ActiveGame.starNumber[22] + ActiveGame.starNumber[23]
                                                + ActiveGame.starNumber[24] + ActiveGame.starNumber[25] + ActiveGame.starNumber[26]
                                                + ActiveGame.starNumber[27] + ActiveGame.starNumber[28] + ActiveGame.starNumber[29]
                                                + ActiveGame.starNumber[30] + ActiveGame.starNumber[31] + ActiveGame.starNumber[32]
                                                + ActiveGame.starNumber[33] + ActiveGame.starNumber[34] + ActiveGame.starNumber[35]
                                                + ActiveGame.starNumber[36] + ActiveGame.starNumber[37] + ActiveGame.starNumber[38]
                                                + ActiveGame.starNumber[39] + ActiveGame.starNumber[40] + ActiveGame.starNumber[41]
                                                + ActiveGame.starNumber[42] + ActiveGame.starNumber[43] + ActiveGame.starNumber[44]
                                                + ActiveGame.starNumber[45] + ActiveGame.starNumber[46] + ActiveGame.starNumber[47]
                                                + "1"                      + "1"
                                                + ActiveGame.specialLevelsStarNumber[0] + ActiveGame.specialLevelsStarNumber[1]
                                                + ActiveGame.specialLevelsStarNumber[2] + ActiveGame.specialLevelsStarNumber[3]
                                                + ActiveGame.specialLevelsStarNumber[4] + ActiveGame.specialLevelsStarNumber[5]
                                                + ActiveGame.specialLevelsStarNumber[6] + ActiveGame.specialLevelsStarNumber[7]
                                                + ActiveGame.specialLevelsStarNumber[8] + ActiveGame.specialLevelsStarNumber[9]
                                                + ActiveGame.specialLevelsStarNumber[10] + ActiveGame.specialLevelsStarNumber[11]
                                                + ActiveGame.specialLevelsStarNumber[12] + ActiveGame.specialLevelsStarNumber[13]
                                                + ActiveGame.specialLevelsStarNumber[14] + ActiveGame.specialLevelsStarNumber[15]
                                                + ActiveGame.specialLevelsStarNumber[16] + ActiveGame.specialLevelsStarNumber[17]
                                                + ActiveGame.specialLevelsStarNumber[18] + ActiveGame.specialLevelsStarNumber[19]
                                                + ActiveGame.specialLevelsStarNumber[20] + ActiveGame.specialLevelsStarNumber[21]
                                                + ActiveGame.specialLevelsStarNumber[22] + ActiveGame.specialLevelsStarNumber[23];
                }
                else
                {
                    GPG_CloudSaveSystem.Instance.saveString = ActiveGame.lastPlayableLevel.ToString() + ActiveGame.hints.ToString()
                                                + ActiveGame.starNumber[0] + ActiveGame.starNumber[1] + ActiveGame.starNumber[2]
                                                + ActiveGame.starNumber[3] + ActiveGame.starNumber[4] + ActiveGame.starNumber[5]
                                                + ActiveGame.starNumber[6] + ActiveGame.starNumber[7] + ActiveGame.starNumber[8]
                                                + ActiveGame.starNumber[9] + ActiveGame.starNumber[10] + ActiveGame.starNumber[11]
                                                + ActiveGame.starNumber[12] + ActiveGame.starNumber[13] + ActiveGame.starNumber[14]
                                                + ActiveGame.starNumber[15] + ActiveGame.starNumber[16] + ActiveGame.starNumber[17]
                                                + ActiveGame.starNumber[18] + ActiveGame.starNumber[19] + ActiveGame.starNumber[20]
                                                + ActiveGame.starNumber[21] + ActiveGame.starNumber[22] + ActiveGame.starNumber[23]
                                                + ActiveGame.starNumber[24] + ActiveGame.starNumber[25] + ActiveGame.starNumber[26]
                                                + ActiveGame.starNumber[27] + ActiveGame.starNumber[28] + ActiveGame.starNumber[29]
                                                + ActiveGame.starNumber[30] + ActiveGame.starNumber[31] + ActiveGame.starNumber[32]
                                                + ActiveGame.starNumber[33] + ActiveGame.starNumber[34] + ActiveGame.starNumber[35]
                                                + ActiveGame.starNumber[36] + ActiveGame.starNumber[37] + ActiveGame.starNumber[38]
                                                + ActiveGame.starNumber[39] + ActiveGame.starNumber[40] + ActiveGame.starNumber[41]
                                                + ActiveGame.starNumber[42] + ActiveGame.starNumber[43] + ActiveGame.starNumber[44]
                                                + ActiveGame.starNumber[45] + ActiveGame.starNumber[46] + ActiveGame.starNumber[47]
                                                + "0"                      + "1"
                                                + ActiveGame.specialLevelsStarNumber[0] + ActiveGame.specialLevelsStarNumber[1]
                                                + ActiveGame.specialLevelsStarNumber[2] + ActiveGame.specialLevelsStarNumber[3]
                                                + ActiveGame.specialLevelsStarNumber[4] + ActiveGame.specialLevelsStarNumber[5]
                                                + ActiveGame.specialLevelsStarNumber[6] + ActiveGame.specialLevelsStarNumber[7]
                                                + ActiveGame.specialLevelsStarNumber[8] + ActiveGame.specialLevelsStarNumber[9]
                                                + ActiveGame.specialLevelsStarNumber[10] + ActiveGame.specialLevelsStarNumber[11]
                                                + ActiveGame.specialLevelsStarNumber[12] + ActiveGame.specialLevelsStarNumber[13]
                                                + ActiveGame.specialLevelsStarNumber[14] + ActiveGame.specialLevelsStarNumber[15]
                                                + ActiveGame.specialLevelsStarNumber[16] + ActiveGame.specialLevelsStarNumber[17]
                                                + ActiveGame.specialLevelsStarNumber[18] + ActiveGame.specialLevelsStarNumber[19]
                                                + ActiveGame.specialLevelsStarNumber[20] + ActiveGame.specialLevelsStarNumber[21]
                                                + ActiveGame.specialLevelsStarNumber[22] + ActiveGame.specialLevelsStarNumber[23];
                }
            }
            else
            {
                if (ActiveGame.secretLevelsActive == true)
                {
                    GPG_CloudSaveSystem.Instance.saveString =ActiveGame.lastPlayableLevel.ToString() + ActiveGame.hints.ToString()
                                                + ActiveGame.starNumber[0] + ActiveGame.starNumber[1] + ActiveGame.starNumber[2]
                                                + ActiveGame.starNumber[3] + ActiveGame.starNumber[4] + ActiveGame.starNumber[5]
                                                + ActiveGame.starNumber[6] + ActiveGame.starNumber[7] + ActiveGame.starNumber[8]
                                                + ActiveGame.starNumber[9] + ActiveGame.starNumber[10] + ActiveGame.starNumber[11]
                                                + ActiveGame.starNumber[12] + ActiveGame.starNumber[13] + ActiveGame.starNumber[14]
                                                + ActiveGame.starNumber[15] + ActiveGame.starNumber[16] + ActiveGame.starNumber[17]
                                                + ActiveGame.starNumber[18] + ActiveGame.starNumber[19] + ActiveGame.starNumber[20]
                                                + ActiveGame.starNumber[21] + ActiveGame.starNumber[22] + ActiveGame.starNumber[23]
                                                + ActiveGame.starNumber[24] + ActiveGame.starNumber[25] + ActiveGame.starNumber[26]
                                                + ActiveGame.starNumber[27] + ActiveGame.starNumber[28] + ActiveGame.starNumber[29]
                                                + ActiveGame.starNumber[30] + ActiveGame.starNumber[31] + ActiveGame.starNumber[32]
                                                + ActiveGame.starNumber[33] + ActiveGame.starNumber[34] + ActiveGame.starNumber[35]
                                                + ActiveGame.starNumber[36] + ActiveGame.starNumber[37] + ActiveGame.starNumber[38]
                                                + ActiveGame.starNumber[39] + ActiveGame.starNumber[40] + ActiveGame.starNumber[41]
                                                + ActiveGame.starNumber[42] + ActiveGame.starNumber[43] + ActiveGame.starNumber[44]
                                                + ActiveGame.starNumber[45] + ActiveGame.starNumber[46] + ActiveGame.starNumber[47]
                                                + "1"                      + "0"
                                                + ActiveGame.specialLevelsStarNumber[0] + ActiveGame.specialLevelsStarNumber[1]
                                                + ActiveGame.specialLevelsStarNumber[2] + ActiveGame.specialLevelsStarNumber[3]
                                                + ActiveGame.specialLevelsStarNumber[4] + ActiveGame.specialLevelsStarNumber[5]
                                                + ActiveGame.specialLevelsStarNumber[6] + ActiveGame.specialLevelsStarNumber[7]
                                                + ActiveGame.specialLevelsStarNumber[8] + ActiveGame.specialLevelsStarNumber[9]
                                                + ActiveGame.specialLevelsStarNumber[10] + ActiveGame.specialLevelsStarNumber[11]
                                                + ActiveGame.specialLevelsStarNumber[12] + ActiveGame.specialLevelsStarNumber[13]
                                                + ActiveGame.specialLevelsStarNumber[14] + ActiveGame.specialLevelsStarNumber[15]
                                                + ActiveGame.specialLevelsStarNumber[16] + ActiveGame.specialLevelsStarNumber[17]
                                                + ActiveGame.specialLevelsStarNumber[18] + ActiveGame.specialLevelsStarNumber[19]
                                                + ActiveGame.specialLevelsStarNumber[20] + ActiveGame.specialLevelsStarNumber[21]
                                                + ActiveGame.specialLevelsStarNumber[22] + ActiveGame.specialLevelsStarNumber[23];
                }
                else
                {
                    GPG_CloudSaveSystem.Instance.saveString = ActiveGame.lastPlayableLevel.ToString() + ActiveGame.hints.ToString()
                                                + ActiveGame.starNumber[0] + ActiveGame.starNumber[1] + ActiveGame.starNumber[2]
                                                + ActiveGame.starNumber[3] + ActiveGame.starNumber[4] + ActiveGame.starNumber[5]
                                                + ActiveGame.starNumber[6] + ActiveGame.starNumber[7] + ActiveGame.starNumber[8]
                                                + ActiveGame.starNumber[9] + ActiveGame.starNumber[10] + ActiveGame.starNumber[11]
                                                + ActiveGame.starNumber[12] + ActiveGame.starNumber[13] + ActiveGame.starNumber[14]
                                                + ActiveGame.starNumber[15] + ActiveGame.starNumber[16] + ActiveGame.starNumber[17]
                                                + ActiveGame.starNumber[18] + ActiveGame.starNumber[19] + ActiveGame.starNumber[20]
                                                + ActiveGame.starNumber[21] + ActiveGame.starNumber[22] + ActiveGame.starNumber[23]
                                                + ActiveGame.starNumber[24] + ActiveGame.starNumber[25] + ActiveGame.starNumber[26]
                                                + ActiveGame.starNumber[27] + ActiveGame.starNumber[28] + ActiveGame.starNumber[29]
                                                + ActiveGame.starNumber[30] + ActiveGame.starNumber[31] + ActiveGame.starNumber[32]
                                                + ActiveGame.starNumber[33] + ActiveGame.starNumber[34] + ActiveGame.starNumber[35]
                                                + ActiveGame.starNumber[36] + ActiveGame.starNumber[37] + ActiveGame.starNumber[38]
                                                + ActiveGame.starNumber[39] + ActiveGame.starNumber[40] + ActiveGame.starNumber[41]
                                                + ActiveGame.starNumber[42] + ActiveGame.starNumber[43] + ActiveGame.starNumber[44]
                                                + ActiveGame.starNumber[45] + ActiveGame.starNumber[46] + ActiveGame.starNumber[47]
                                                + "0" + "0"
                                                + ActiveGame.specialLevelsStarNumber[0] + ActiveGame.specialLevelsStarNumber[1]
                                                + ActiveGame.specialLevelsStarNumber[2] + ActiveGame.specialLevelsStarNumber[3]
                                                + ActiveGame.specialLevelsStarNumber[4] + ActiveGame.specialLevelsStarNumber[5]
                                                + ActiveGame.specialLevelsStarNumber[6] + ActiveGame.specialLevelsStarNumber[7]
                                                + ActiveGame.specialLevelsStarNumber[8] + ActiveGame.specialLevelsStarNumber[9]
                                                + ActiveGame.specialLevelsStarNumber[10] + ActiveGame.specialLevelsStarNumber[11]
                                                + ActiveGame.specialLevelsStarNumber[12] + ActiveGame.specialLevelsStarNumber[13]
                                                + ActiveGame.specialLevelsStarNumber[14] + ActiveGame.specialLevelsStarNumber[15]
                                                + ActiveGame.specialLevelsStarNumber[16] + ActiveGame.specialLevelsStarNumber[17]
                                                + ActiveGame.specialLevelsStarNumber[18] + ActiveGame.specialLevelsStarNumber[19]
                                                + ActiveGame.specialLevelsStarNumber[20] + ActiveGame.specialLevelsStarNumber[21]
                                                + ActiveGame.specialLevelsStarNumber[22] + ActiveGame.specialLevelsStarNumber[23];
                }
            }
            if (ActiveGame.goldCoin==0)
            {
                GPG_CloudSaveSystem.Instance.saveString += "0" + "0" + "0" + "0";
            }
            else if (ActiveGame.goldCoin<100)
            {
                GPG_CloudSaveSystem.Instance.saveString +="0"+"0"+ActiveGame.goldCoin;
            }else if (ActiveGame.goldCoin>=100&&ActiveGame.goldCoin<1000)
            {
                GPG_CloudSaveSystem.Instance.saveString += "0" + ActiveGame.goldCoin;
            }
            else if (ActiveGame.goldCoin >= 1000)
            {
                GPG_CloudSaveSystem.Instance.saveString +=ActiveGame.goldCoin;
            }
            GPG_CloudSaveSystem.Instance.SaveToCloud();
        }
    }
    

}
