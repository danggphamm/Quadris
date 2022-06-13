using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loseDisable : MonoBehaviour
{
    Camera mainCam;
    private GameObject gridCreator;

    // Start is called before the first frame update
    void Start()
    {
        gridCreator = GameObject.Find("Grid creator");
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        bool loseGame = gridCreator.GetComponent<NodeSpawner>().CheckLoseGame();

        if (loseGame == true)
        {
            GetComponent<Image>().enabled = false;
        }
    }
}
