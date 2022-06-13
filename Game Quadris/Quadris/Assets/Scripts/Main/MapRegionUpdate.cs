using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapRegionUpdate : MonoBehaviour
{
    public int lowestLevelOfRegion;

    // Update is called once per frame
    void Update()
    {
        if(GameController.playerData.currentLevel >= lowestLevelOfRegion)
        {
            GetComponent<Image>().enabled = true;
        }

        else
            GetComponent<Image>().enabled = false;
    }
}
