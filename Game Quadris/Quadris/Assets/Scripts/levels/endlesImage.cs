using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endlesImage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Image>() != null)
        {
            GetComponent<Image>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.playerData.currentLevel >= 10)
        {
            GetComponent<Image>().enabled = true;
        }
    }
}
