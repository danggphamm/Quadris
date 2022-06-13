using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagesOfComboMenu : MonoBehaviour
{
    private bool isActive;
    private Image thisImg;
    public int levelToShow;
    public int thisRegion;
    public int pageToHide;
    private int currentLevel;
    private int currentRegion;

    Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        thisImg = GetComponent<Image>();
        mainCam = Camera.main;
        currentLevel = mainCam.GetComponent<GameController>().currentLevel;
    }

    // Update is called once per frame
    void Update()
    {
        isActive = mainCam.GetComponent<comboMenu>().getActiveness();
        currentRegion = mainCam.GetComponent<comboMenu>().getRegion();

        if (isActive && currentLevel >= levelToShow && (thisRegion == currentRegion || thisRegion == 100))
        {
            thisImg.enabled = true;

            if(thisRegion == 100)
            {
                if(pageToHide == currentRegion)
                {
                    thisImg.enabled = false;
                }
            }
        }

        else
        {
            thisImg.enabled = false;
        }
    }
}
