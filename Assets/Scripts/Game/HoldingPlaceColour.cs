using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class HoldingPlaceColour : MonoBehaviour
{
    Color red = new Color(255f, 0f, 0f, 0.25f);
    Color white = new Color(255f, 255f, 255f, 0.25f);
    void Update()
    {
        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (gameObj.tag == "item" && gameObj != SceneController.lastClicked)
            {

                
                gameObj.transform.Find("HoldingPlace").GetComponent<SpriteRenderer>().color= white;
            }
            else if (gameObj.tag == "item" && gameObj == SceneController.lastClicked)
            {
                SceneController.lastClicked.transform.Find("HoldingPlace").GetComponent<SpriteRenderer>().color= red;
            }
        }
    }
}
