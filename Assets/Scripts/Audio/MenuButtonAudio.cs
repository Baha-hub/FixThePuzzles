using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonAudio : MonoBehaviour
{
    public GameObject clickSound;
    public void PlaySound()
    {
        if (ActiveGame.soundsOn)
        {
            if (clickSound)
            {
                clickSound.SetActive(false);
                clickSound.SetActive(true);
            }
            else
            {
                clickSound.SetActive(true);
            }
        }
    }
}
