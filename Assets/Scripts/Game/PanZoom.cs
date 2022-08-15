using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour
{
    Vector3 touchStart;
    public static float zoomOutMin = 5;
    public static float zoomOutMax = 8;
    public float dragSpeed = 2.0f;
    private Vector3 dragOrigin;
    private bool isPanning;
    void Update()
    {
        if (!DragAndDrop.isHold && !Rotates.isEditing && (Input.touchCount==0 || Input.touchCount==1))
        {
            if (Input.GetMouseButtonDown(0))
            {
                touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

                float difference = currentMagnitude - prevMagnitude;

                zoom(difference * 0.01f);
            }
            else if (Input.GetMouseButton(0))
            {
                Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Camera.main.transform.position += direction;

            }
            zoom(Input.GetAxis("Mouse ScrollWheel"));
            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = Input.mousePosition;
                isPanning = true;
            }

            if (!Input.GetMouseButton(0))
            {
                isPanning = false;
            }

            if (isPanning)
            {
                Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);

                Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);
                transform.Translate(move, Space.Self);

                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10, 10), Mathf.Clamp(transform.position.y, -10, 10),-10);
            }
        }
    }

    public static void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}