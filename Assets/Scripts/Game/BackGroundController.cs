using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    public GameObject editableBackGround;

    public void BackGroundChanger()
    {
        if (SceneController.isEditable)
        {
            editableBackGround.SetActive(true);
        }
        else
        {
            editableBackGround.SetActive(false);
        }

    }
    private void Update()
    {
        BackGroundChanger();
    }
}
