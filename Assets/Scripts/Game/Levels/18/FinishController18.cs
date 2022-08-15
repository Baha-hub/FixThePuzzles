using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinishController18 : MonoBehaviour
{

    public GameObject finishScreen;
    public static bool restartControl = false;
    public static bool control1 = false, control2 = false;

    public int CalculateStar()
    {
        if (SceneController.usedItemAmount == 1)
            return 3;
        else if (SceneController.usedItemAmount == 3)
            return 2;
        else
            return 3;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball1")
        {
            control1 = true;
        }
        if (collision.gameObject.tag == "Ball")
        {
            control2 = true;
            if (control1==true && control2==true)
            {
                SceneController.tempStarAmount = 0;
                int starAmount = CalculateStar();
                UIController.ShowOnlyUI();
                if (ActiveGame.starNumber[SceneManager.GetActiveScene().buildIndex - 1] > starAmount)
                {
                    SceneController.tempStarAmount = ActiveGame.starNumber[SceneManager.GetActiveScene().buildIndex - 1];
                    ActiveGame.starNumber[SceneManager.GetActiveScene().buildIndex - 1] = starAmount;
                }
                else if (ActiveGame.starNumber[SceneManager.GetActiveScene().buildIndex - 1] == 0)
                {
                    ActiveGame.starNumber[SceneManager.GetActiveScene().buildIndex - 1] = starAmount;
                    ActiveGame.lastPlayableLevel++;
                }
                else
                {
                    ActiveGame.starNumber[SceneManager.GetActiveScene().buildIndex - 1] = starAmount;
                }
                UIController.SceneRefresh();
                finishScreen.SetActive(true);
            }
        }
    }
    private void Update()
    {
        if (SceneController.isEditable)
        {
            restartControl = true;
        }
        else if (restartControl)
        {
            control1 = false;
            control2 = false;
            restartControl = false;
        }
    }
}
