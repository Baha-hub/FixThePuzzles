using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragAndDrop : MonoBehaviour
{
    private static float startPosX;
    private static float startPosY;
    public static bool isHold = false;
    public void OnMouseDown()
    {
        if (SceneController.isEditable)
            if (Input.GetMouseButtonDown(0))
            {
                SceneController.lastClicked = this.gameObject;
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                startPosX = mousePos.x - this.transform.localPosition.x;
                startPosY = mousePos.y - this.transform.localPosition.y;

                isHold = true;
            }
    }
    public void OnMouseUp()
    {
        isHold = false;
    }
    private void Update()
    {
        if (Input.touchCount==1 || Input.touchCount ==0)
        {
            if (SceneController.isEditable)
                if (ItemBar.isMouseDown)
                {
                    Vector3 mousePos;
                    mousePos = Input.mousePosition;
                    mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                    SceneController.lastClicked.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.position.z);
                }

            if (SceneController.isEditable)
            {
                if (isHold == true)
                {
                    Vector3 mousePos;
                    mousePos = Input.mousePosition;
                    mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                    SceneController.lastClicked.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.position.z);

                }
            }
        }
    }
}
