using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    private Vector3 position;
    private Quaternion rotation;
    private int oneTimeChecker = 0;
    void Update()
    {
        if (SceneController.isEditable)
        {
            if (oneTimeChecker > 0)
            {
                GetUrOwnLocation();
            }
            position = gameObject.transform.localPosition;
            rotation.eulerAngles = gameObject.transform.rotation.eulerAngles;

        }
        else
        {
            oneTimeChecker = 1;
        }

    }
    private void GetUrOwnLocation()
    {
        gameObject.transform.localPosition = position;
        gameObject.transform.eulerAngles = rotation.eulerAngles;
        oneTimeChecker = 0;
    }
}
