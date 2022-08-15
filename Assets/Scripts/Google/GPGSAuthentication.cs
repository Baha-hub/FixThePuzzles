using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections;

public class GPGSAuthentication : MonoBehaviour
{
    public GooglePlaySavePoppup googlePlaySavePoppup;
    public static PlayGamesPlatform platform;
    public GameObject screenBlock;
    void Start()
    {
        SaveSystem.Load();
        if (platform == null)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().EnableSavedGames().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            platform = PlayGamesPlatform.Activate();
            SignIn();
        }
    }
    private void Update()
    {
        if (ActiveGame.firstOpen == false)
        {
            screenBlock.SetActive(true);
        }
        else
        {
            screenBlock.SetActive(false);
        }
    }
    public void SignIn()
    {
        ActiveGame.firstOpen = false;
        Social.Active.localUser.Authenticate(success =>
        {
            if (success)
            {
                if (!(Application.internetReachability == NetworkReachability.NotReachable))
                {
                    StartCoroutine(WaitBeforeLoad());
                }
                else
                {
                    PlayGamesPlatform.Instance.SignOut();
                    ActiveGame.firstOpen = true;
                }
            }
            else
            {
                ActiveGame.firstOpen = true;
            }
        });
    }
    public void GuestSignIn()
    {
        PlayGamesPlatform.Instance.SignOut();
        SceneManager.LoadScene("MainMenu");
    }
    
    //#########################################################################
    // save dosyasını yüklemek için çıkan popup kapanıyor
    
    IEnumerator WaitBeforeLoad() // eski save dosyasını kullanmak istiyor musun sorusunu sormadan önce 1 sn bekliyor bu google bağlantısının gecikebilmesi durumunda sorun oluşmaması için kullanılıyor.
    {
        yield return new WaitForSeconds(1f);
        GPG_CloudSaveSystem.Instance.LoadFromCloud();
        yield return new WaitForSeconds(4f);
        googlePlaySavePoppup.LoadOldSaveFromCloud();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainMenu");
    }
}
