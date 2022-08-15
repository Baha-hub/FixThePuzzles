using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateButtonSetActive : MonoBehaviour
{
    public GameObject rotateButtonSetActive;
    void OnMouseOver() {
        if(Input.GetMouseButtonUp(0)){
            rotateButtonSetActive.SetActive(true);
        }
    }

}
