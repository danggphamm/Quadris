using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraStayInPlace : MonoBehaviour
{ 
    private static Vector3 savedPosition;
    Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;

        mainCam.transform.position = new Vector3(savedPosition.x, savedPosition.y, -10);
    }

    // Update is called once per frame
    void Update()
    {
        savedPosition = new Vector3(mainCam.transform.position.x, mainCam.transform.position.y, -10);
    }
}
