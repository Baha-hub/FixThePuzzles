using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinishController16 : MonoBehaviour
{

    public GameObject finishScreen;

    public int CalculateStar()
    {
        if (SceneController.usedItemAmount == 2)
            return 3;
        else if (SceneController.usedItemAmount == 3)
            return 2;
        else
            return 3;
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
}
