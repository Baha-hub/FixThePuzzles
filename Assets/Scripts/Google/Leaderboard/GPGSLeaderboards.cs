using UnityEngine;

public class GPGSLeaderboards : MonoBehaviour
{
    public void OpenLeaderboard(){
        Social.ShowLeaderboardUI();
    }
    public static void UpdateLeaderboardScore(){
        Social.ReportScore(ActiveGame.googleLeaderBoardScore, GPGSIds.leaderboard_high_score,(success =>{ }));
    }
}
