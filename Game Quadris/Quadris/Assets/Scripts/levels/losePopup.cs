using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class losePopup : MonoBehaviour
{
    Camera mainCam;

    bool endless;

    public GameObject gridCreator;

    public Transform thisObject;

    public Text endlessLevelText;

    public Text newHighScore;

    int originalScore = 0;

    bool loseGame = false;

    // Start is called before the first frame update
    void Start()
    {
        originalScore = GameController.playerData.endlessHighScore;

        thisObject.GetComponent<Image>().enabled = false;
        thisObject.GetComponentInChildren<Text>().enabled = false;
           
        if(endlessLevelText != null)
        {
            endlessLevelText.enabled = false;
        }

        if(newHighScore != null)
        {
            newHighScore.enabled = false;
        }

        mainCam = Camera.main;
        endless = mainCam.GetComponent<levelStats>().endless;
    }

    // Update is called once per frame
    void Update()
    {
        loseGame = gridCreator.GetComponent<NodeSpawner>().CheckLoseGame();

        if (loseGame == true)
        {
            thisObject.GetComponent<Image>().enabled = true;
            thisObject.GetComponentInChildren<Text>().enabled = true;

            if (endless && endlessLevelText != null)
            {
                endlessLevelText.enabled = true;

                endlessLevelText.text = "Your score: " + mainCam.GetComponent<levelStats>().score.ToString();

                if(mainCam.GetComponent<levelStats>().score > originalScore && newHighScore != null)
                {
                    newHighScore.enabled = true;
                }
            }
        }
    }
}
