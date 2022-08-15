using GooglePlayGames.BasicApi.SavedGame;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;

public class GooglePlaySavePoppup : MonoBehaviour
{
    public void LoadOldSaveFromCloud()
    {
        try
        {
            //#########################################################################
            //save dosyasının 0 ve 1. indexinde bulunan degerleri alıp son kalınan level olarak atıyor.
            int lastplaylablelevelOnGoogle = int.Parse("" + GPG_CloudSaveSystem.Instance.saveString[0] + GPG_CloudSaveSystem.Instance.saveString[1]);
            //#########################################################################
            // save dosyasının 2. indeksindeki değeri alıp hints degeri olarak atıyor.
            int hintsOnGoogle = int.Parse("" + GPG_CloudSaveSystem.Instance.saveString[2]);
            //#########################################################################
            // save dosyasında 3. ve 14. indexler dahil araya bakıyor ve hangi bölümde kaç yıldız olması gerekiyorsa save dosyasına eklyior.
            for (int i = 3; i < 51; i++)
            {
                ActiveGame.starNumber[i - 3] = int.Parse(GPG_CloudSaveSystem.Instance.saveString[i].ToString());
            }
            //#########################################################################
            // save dosyasının 15. indexinde bulunan deger 1 ise gizli bölümleri aktif ediyor. 0 ise deaktif.
            if (GPG_CloudSaveSystem.Instance.saveString[51] == '1')
            {
                ActiveGame.secretLevelsActive = true;
            }
            else
            {
                ActiveGame.secretLevelsActive = false;
            }
            //#########################################################################
            // save dosyasında 16. indexte bulunan reklamlar aktif mi yoksa değilmi indexinin degeri 1 ise true 0 ise false şeklinde değiştiriyor.
            if (GPG_CloudSaveSystem.Instance.saveString[52] == '1')
            {
                ActiveGame.adsEnabled = true;
            }
            else
            {
                ActiveGame.adsEnabled = false;
            }
            //#########################################################################
            // Special level yıldız miktarlarını alıyoruz.
            for (int i = 53; i < 77; i++)
            {
                ActiveGame.specialLevelsStarNumber[i - 53] = int.Parse(GPG_CloudSaveSystem.Instance.saveString[i].ToString());
            }
            //#########################################################################
            // Gold miktarını alıyoruz
            ActiveGame.goldCoin = int.Parse(GPG_CloudSaveSystem.Instance.saveString[77].ToString()+ GPG_CloudSaveSystem.Instance.saveString[78].ToString() + GPG_CloudSaveSystem.Instance.saveString[79].ToString() + GPG_CloudSaveSystem.Instance.saveString[80].ToString());
            //#########################################################################
            // aldığı hints bilgisini atıyor.
            ActiveGame.hints = hintsOnGoogle;

            //#################################################################
            // default olarak oluşturuluyor gereksiz save detayları...
            ActiveGame.musicOn = true;
            ActiveGame.soundsOn = true;
            ActiveGame.levelSize = 48;
            ActiveGame.lastPlayableLevel = lastplaylablelevelOnGoogle;
            if (ActiveGame.lastPlayableLevel < 2)
            {
                ActiveGame.tutorialOneDone = false;
            }
            else
            {
                ActiveGame.tutorialOneDone = true;
            }
            ActiveGame.en = true;
            ActiveGame.tr = false;
            ActiveGame.googleLeaderBoardScore = 0;
            ActiveGame.haveCloudSave = true;
            //#############################################################
            // hemen bir save alıyor ve aynı sayfayı yüklüyor...
            SaveSystem.Save();
            SaveSystem.Load();
        }
        catch
        {
            if (Social.localUser.authenticated && ActiveGame.haveCloudSave)
            {
                PlayGamesPlatform.Instance.SignOut();
            }
            SceneManager.LoadScene("AuthenticationScreen");
        }
    }
}
