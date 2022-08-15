using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxControll : MonoBehaviour
{
    void Update()
    {
        if (SceneController.isEditable)
        {
            this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
