using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragScreen : MonoBehaviour
{
    private Vector3 mouseOrigin;
    private Vector3 screenOrigin;
    public float xLimit;
    public float mouseSpeed  = 0.5f;

    float camHeight;
    float camWidth;

    float imgHeight;
    float imgWidth;

    Camera mainCam;

    private bool isHeld;

    void Start()
    {
        mainCam = Camera.main;

        camHeight = 2f * mainCam.orthographicSize;
        camWidth = camHeight * mainCam.aspect;

        imgWidth = GetComponent<RectTransform>().rect.width;
        imgHeight = GetComponent<RectTransform>().rect.height;

        isHeld = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isHeld == true)
        {
            mainCam.transform.position = new Vector3(screenOrigin.x - (Input.mousePosition.x - mouseOrigin.x)*mouseSpeed,
                                                         screenOrigin.y - (Input.mousePosition.y - mouseOrigin.y)*mouseSpeed, -10);

            if(mainCam.transform.position.x < 0)
            {
                mainCam.transform.position = new Vector3(0, mainCam.transform.position.y, -10);
            }

            if (mainCam.transform.position.y > 0)
            {
                mainCam.transform.position = new Vector3(mainCam.transform.position.x, 0, -10);
            }

            if(mainCam.transform.position.x > xLimit)
            {
                mainCam.transform.position = new Vector3(xLimit, mainCam.transform.position.y, -10);
            }

            if (mainCam.transform.position.y < 0)
            {
                mainCam.transform.position = new Vector3(mainCam.transform.position.x, 0, -10);
            }
        }
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isHeld = true;
            mouseOrigin = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10);
            screenOrigin = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -10);
        }
    }

    void OnMouseUp()
    {
        isHeld = false;
    }
}
