using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboMenuPages : MonoBehaviour
{
    public GameObject Menu;
    bool isActive;
    public Sprite page1;
    public Sprite page2;
    public Sprite page3;
    int currentPage;

    // Update is called once per frame
    void Update()
    {
        currentPage = Menu.GetComponent<comboMenu>().getRegion();

        if(currentPage == 1 || currentPage == 0)
        {
            GetComponent<Image>().sprite = page1;
        }

        else if (currentPage == 2)
        {
            GetComponent<Image>().sprite = page2;
        }

        else if (currentPage == 3)
        {
            GetComponent<Image>().sprite = page3;
        }
    }
}
