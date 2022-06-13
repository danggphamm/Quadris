using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelButtonImageLocker : MonoBehaviour
{
    public GameObject thisGlobe;
    private int level;
    private bool endless;

    void Start()
    {
        GetComponent<Image>().enabled = false;
        level = thisGlobe.GetComponent<changeLockedSprite>().levelNumber;
        endless = thisGlobe.GetComponent<changeLockedSprite>().endless;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.playerData.currentLevel >= level)
        {
            GetComponent<Image>().enabled = true;
        }

        else if(endless && GameController.playerData.currentLevel >= 10)
        {
            GetComponent<Image>().enabled = true;
        }
    }
}
