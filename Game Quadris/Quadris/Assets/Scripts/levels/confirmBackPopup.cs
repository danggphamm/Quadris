using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class confirmBackPopup : MonoBehaviour
{
    void Start()
    {
        GetComponent<Image>().enabled = false;
        GetComponentInChildren<Text>().enabled = false;
    }

    public void active()
    {
        GetComponent<Image>().enabled = true;
        GetComponentInChildren<Text>().enabled = true;
    }

    public void inactive()
    {
        GetComponent<Image>().enabled = false;
        GetComponentInChildren<Text>().enabled = false;
    }
}
