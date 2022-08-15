using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject star1, star2, star3;
    public GameObject blockPanel;
    public void StartLevel()
    {
        Time.timeScale = 1.0f;
        SceneController.isEditable = false;
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        ShowOnlyUI();
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        UIController.SceneRefresh();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        ShowAllGame();
    }
    public void RestartGame()
    {
        ActiveGame.ads_Amount++;
        Time.timeScale = 1f;
        UIController.SceneRefresh();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameRefresh()
    {
        ActiveGame.ads_Amount++;
        if (SceneController.isEditable)
        {
            Time.timeScale = 1f;
            UIController.SceneRefresh();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            UIController.SceneRefresh2();
        }
    }
    public void FinishScreen()
    {
        blockPanel.SetActive(true);
        if (ActiveGame.starNumber[SceneManager.GetActiveScene().buildIndex - 1] == 1)
        {
            star1.SetActive(true);
        }
        else if (ActiveGame.starNumber[SceneManager.GetActiveScene().buildIndex - 1] == 2)
        {
            star1.SetActive(true);
            star2.SetActive(true);

        }
        else if (ActiveGame.starNumber[SceneManager.GetActiveScene().buildIndex - 1] == 3)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        if (SceneController.tempStarAmount != 0)
        {
            ActiveGame.starNumber[SceneManager.GetActiveScene().buildIndex - 1] = SceneController.tempStarAmount;
            SceneController.tempStarAmount = 0;
        }
        UIController.SceneRefresh();
    }
    public void GoMainMenu()
    {
        UIController.SceneRefresh();
        SaveSystem.Save();
        SceneManager.LoadScene("MainMenu");
    }
    public static void SceneRefresh()
    {
        SceneController.isEditable = true;
        SceneController.isLevelFinished = false;
        SceneController.isStartable = true;
        SceneController.usedItemAmount = 0;
    }
    public static void SceneRefresh2()
    {
        SceneController.isEditable = true;
        SceneController.isLevelFinished = false;
        SceneController.isStartable = true;
    }
    public static void ShowOnlyUI()
    {
        Camera.main.GetComponent<Camera>().cullingMask = (1 << LayerMask.NameToLayer("UI"));
    }
    public static void ShowAllGame()
    {
        Camera.main.GetComponent<Camera>().cullingMask = (1 << LayerMask.NameToLayer("Default")) | (1 << LayerMask.NameToLayer("TransparentFX")) | (1 << LayerMask.NameToLayer("Ignore Raycast")) | (1 << LayerMask.NameToLayer("UI")) | (1 << LayerMask.NameToLayer("Water")) | (1 << LayerMask.NameToLayer("BackGround Image")) | (1 << LayerMask.NameToLayer("Post Processing"));
    }
}
