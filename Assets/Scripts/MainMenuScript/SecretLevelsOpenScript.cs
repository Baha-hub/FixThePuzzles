using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretLevelsOpenScript : MonoBehaviour
{
    public GameObject onNormalLevels, offSecretLevels,levels,secretLevels,secretLevelLock;

    public void ChangeLevels()
    {
        if (onNormalLevels.activeSelf==true)
        {
            offSecretLevels.SetActive(true);
            onNormalLevels.SetActive(false);
            levels.SetActive(false);
            secretLevels.SetActive(true);
            if (ActiveGame.secretLevelsActive == true)
            {
                secretLevelLock.SetActive(false);
            }
            else
                secretLevelLock.SetActive(true);
        }
        else
        {
            offSecretLevels.SetActive(false);
            onNormalLevels.SetActive(true);
            levels.SetActive(true);
            secretLevels.SetActive(false);
        }
    }

}
