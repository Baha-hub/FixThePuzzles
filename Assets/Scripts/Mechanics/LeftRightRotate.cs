using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightRotate : MonoBehaviour
{
    public static GameObject lastClicked;
    

    public void LeftRotate(){
        lastClicked.transform.Rotate(0,0,+10.0f);
    }
    public void RightRotate(){
        lastClicked.transform.Rotate(0,0,-10.0f);
    }
}
