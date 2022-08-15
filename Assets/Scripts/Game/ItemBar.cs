using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBar : MonoBehaviour
{
    public Text amountt;
    public GameObject item;
    GameObject tempItem;
    public int amount;
    public static bool isMouseDown = false;
    public static bool isDragging = false;
    public void OnMouseDown()
    {
        if (SceneController.isEditable)
            if (!isDragging)
            {

                if (amount > 0)
                {
                    tempItem = Instantiate(item, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1), Quaternion.identity);
                    SceneController.lastClicked = tempItem;
                    amount--;
                    SceneController.usedItemAmount++;
                    Rotates.isEditing = true;
                    if (amount == 0)
                    {
                        this.gameObject.GetComponent<Image>().enabled = false;
                        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        this.gameObject.transform.Find("Image").GetComponentInChildren<Image>().enabled = false;
                        if(this.gameObject.transform.Find("Image (1)") != null)
                        {
                            this.gameObject.transform.Find("Image (1)").GetComponent<Image>().enabled = false;
                        }
                    }
                    isMouseDown = true;
                    isDragging = true;
                }
            }
    }
    public void OnMouseUp()
    {
        if (SceneController.isEditable)
        {
            Rotates.isEditing = false;
            isMouseDown = false;
            isDragging = false;
        }
    }
    public void Update()
    {
        if (amount != 0)
            amountt.text = amount.ToString();
        else
            amountt.text = "";
    }
}
