﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinishController4 : MonoBehaviour
{
    public GameObject finishScreen;
    public static int itemControl = 0;
   // bool control1 = true, control2 = true;
   // bool restartControl=false;

    public int CalculateStar()
    {
        if (SceneController.usedItemAmount == 1)
            return 3;
        else
            return 1;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
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
    /*private void Update()
     {
         if (SceneController.isEditable)
         {
             restartControl = true;
         }
         else if(restartControl)
         {
             control1 = true;
             control2 = true;
             itemControl = 0;
             restartControl = false;
         }
     }*/
}
