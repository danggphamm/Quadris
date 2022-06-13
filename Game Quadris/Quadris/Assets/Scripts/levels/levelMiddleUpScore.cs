using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelMiddleUpScore : MonoBehaviour
{
    public Text thisText;

    Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        thisText.text = mainCam.GetComponent<levelStats>().score.ToString();
    }
}