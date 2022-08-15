using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rotates : MonoBehaviour
{
    public static bool isEditing=false;
    public void LeftRotate()
    {
        if (SceneController.lastClicked == null)
        {

        }
        else if(SceneController.isEditable)
            SceneController.lastClicked.transform.Rotate(0, 0, 10.0f);
    }
    public void RightRotate()
    {
        if (SceneController.lastClicked == null)
        {

        }
        else if (SceneController.isEditable)
            SceneController.lastClicked.transform.Rotate(0, 0, -10.0f);
    }
    public void OnMouseDown()
    {
        isEditing = true;
    }
    public void OnMouseUp()
    {
        isEditing = false;
    }
}
