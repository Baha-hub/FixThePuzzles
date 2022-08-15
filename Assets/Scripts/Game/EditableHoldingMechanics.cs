using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditableHoldingMechanics : MonoBehaviour
{
    void Update()
    {
        if (SceneController.isEditable == false)
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (SceneController.isEditable == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
