using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textPopup : MonoBehaviour
{
    public void show()
    {
        transform.GetComponent<Text>().enabled = true;
    }

    public void hide()
    {
        transform.GetComponent<Text>().enabled = false;
    }
}
