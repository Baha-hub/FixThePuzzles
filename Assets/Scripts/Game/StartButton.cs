using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public GameObject startButton;
    void Update()
    {
        startButton.SetActive(SceneController.isStartable);
        if (SceneController.isEditable == false)
        {
            startButton.SetActive(false);
        }
    }
}
