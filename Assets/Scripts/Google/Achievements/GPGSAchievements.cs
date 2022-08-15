using UnityEngine;
using GooglePlayGames;

public class GPGSAchievements : MonoBehaviour
{
    public void OpenAchievementPanel(){
        Social.ShowAchievementsUI();
    }
    public void UpdateIncrementalAds(){
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_supporter,1, (bool success) => {

        });
    }
    public void UnlockFirstLevel(){
        Social.ReportProgress(GPGSIds.achievement_first_level,100f,null);
    }
    public void UnlockFifthLEvel(){
        Social.ReportProgress(GPGSIds.achievement_fifth_level,100f,null);
    }
    public void UnlockTwentiethLevel(){
        Social.ReportProgress(GPGSIds.achievement_twentieth_level,100f,null);
    }
}
