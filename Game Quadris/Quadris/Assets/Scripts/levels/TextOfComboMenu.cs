using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOfComboMenu : MonoBehaviour
{
    private bool isActive;
    private Text thisText;
    Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        thisText = GetComponent<Text>();
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        isActive = mainCam.GetComponent<comboMenu>().getActiveness();

        if (isActive)
        {
            thisText.enabled = true;
        }

        else
        {
            thisText.enabled = false;
        }
    }
}
