using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControlScript : MonoBehaviour
{
    [SerializeField]
    List<GameObject> stars, Locks;

    private void Start()
    {
        OpenLevels();
        OpenStars();
    }
    private void OpenLevels()
    {
        for (int i = 0; i < ActiveGame.lastPlayableLevel; i++)
        {
            Locks[i].SetActive(false);
        }
    }
    private void OpenStars()
    {
        for (int i = 0; i < ActiveGame.lastPlayableLevel; i++)
        {
            if (ActiveGame.starNumber[i] == 1)
            {
                stars[(i * 3)].SetActive(true);
            }
            else if (ActiveGame.starNumber[i] == 2)
            {
                stars[(i * 3)].SetActive(true);
                stars[(i * 3) + 1].SetActive(true);
            }
            else if (ActiveGame.starNumber[i] == 3)
            {
                stars[(i * 3)].SetActive(true);
                stars[(i * 3) + 1].SetActive(true);
                stars[(i * 3) + 2].SetActive(true);
            }
        }
    }
}
