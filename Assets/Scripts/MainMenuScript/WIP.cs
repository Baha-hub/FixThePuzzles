using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIP : MonoBehaviour
{
    void Update()
    {
        if (ActiveGame.lastPlayableLevel==9)
        {
            gameObject.transform.position = new Vector2(800,450);
        }
        ActiveGame.hints = 9;
    }
}
