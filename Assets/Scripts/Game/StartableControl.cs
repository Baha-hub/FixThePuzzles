using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartableControl : MonoBehaviour
{
    private void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.GetComponent<Collider2D>().IsTouching(collision)&&collision.tag!= "HoldingPlace")
        {
            SceneController.isStartable = false;
            if(SceneController.isEditable)
                gameObject.transform.parent.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f, 1f);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "HoldingPlace")
        {
            SceneController.isStartable = true;
            gameObject.transform.parent.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 1f);
        }
    }
    
}
