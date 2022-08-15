using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    public GameObject hintImage;
    public void ShowHint()
    {
        if (ActiveGame.hints>0)
        {
            hintImage.SetActive(true);
            ActiveGame.hints--;
            Destroy(this.gameObject);
        }
        else
        {
            //show Poppup
        }
    }
}
