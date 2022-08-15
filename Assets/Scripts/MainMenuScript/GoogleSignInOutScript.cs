using GooglePlayGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoogleSignInOutScript : MonoBehaviour
{
    public GameObject googleSignedIn, googleSignedOut;
    public void Update()
    {
        if (CheckGoogleSituation() == true)
        {
            googleSignedOut.SetActive(true);
            googleSignedIn.SetActive(false);
        }
        else
        {
            googleSignedOut.SetActive(false);
            googleSignedIn.SetActive(true);
        }

    }
    public static bool CheckGoogleSituation()
    {
        if (Social.localUser.authenticated)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void GoogleSingedIn()
    {
            SignIn();
    }
    public void GoogleSignedOut()
    {
        ActiveGame.firstOpen = true;
        SaveSystem.Save();
        SignOut();
    }
    public void SignOut()
    {
        if (Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.SignOut();
            SaveSystem.DefaultLoadGame();
            SaveSystem.Save();
            SceneManager.LoadScene("AuthenticationScreen");
        }
    }
    public void SignIn()
    {
        SceneManager.LoadScene("AuthenticationScreen");
    }
}