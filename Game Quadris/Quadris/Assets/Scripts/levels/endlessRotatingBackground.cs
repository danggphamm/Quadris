using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endlessRotatingBackground : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(GameController.playerData.currentLevel >= 10)
        {
            GetComponent<rotatingImage>().started = true;
        }
    }
}
