using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class comboMenu : MonoBehaviour
{
    private bool menuActive = false;
    private static int region = 1;

    // Start is called before the first frame update
    void Start()
    {
        menuActive = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void show()
    {
        menuActive = true;
    }

    public void hide()
    {
        menuActive = false;
    }

    public bool getActiveness()
    {
        return menuActive;
    }

    public int getRegion()
    {
        return region;
    }

    public void nextPage()
    {
        if(region < 3)
        {
            region ++;
        }
    }

    public void previousPage()
    {
        if(region > 1)
        {
            region--;
        }
    }
}
