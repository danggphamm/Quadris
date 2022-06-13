using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imagePopup : MonoBehaviour
{
    private Image[] childrenImages;
    public Text[] goalText;
    bool enabling = false;

    void Start()
    {
        childrenImages = transform.GetComponentsInChildren<Image>();

        hide();
    }


    public void show()
    {
        foreach (Image img in childrenImages)
        {
            img.enabled = true;
            if (img.GetComponentInChildren<Text>() != null)
            {
                img.GetComponentInChildren<Text>().enabled = true;
            }
        }

        foreach(Text txt in goalText)
        {
            txt.GetComponent<Text>().enabled = false;
        }

        enabling = true;
    }

    public void hide()
    {
        foreach (Image img in childrenImages)
        {
            img.enabled = false;
            if (img.GetComponentInChildren<Text>() != null)
            {
                img.GetComponentInChildren<Text>().enabled = false;
            }
        }

        foreach (Text txt in goalText)
        {
            txt.GetComponent<Text>().enabled = true;
        }

        enabling = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(enabling == true)
            {
                hide();
            }
        }
    }
}
