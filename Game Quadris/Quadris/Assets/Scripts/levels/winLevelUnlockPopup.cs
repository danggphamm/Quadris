using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winLevelUnlockPopup : MonoBehaviour
{
    Camera mainCam;

    public Text regionUnlock;
    public Image thisChildrenImage;
    public Image rotatingBackgroundImage;

    private int level;
    private int currentLevel;
    public float waitTime = 1.5f;
    private bool waited = false;

    bool winGame = false;

    public float popupDuration = 7.5f;
    float waitTimer = 0f;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        level = mainCam.GetComponent<levelStats>().level;
        currentLevel = GameController.playerData.currentLevel;

        thisChildrenImage.enabled = false;
        rotatingBackgroundImage.enabled = false;
        GetComponentInChildren<Text>().enabled = false;
        regionUnlock.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        winGame = mainCam.GetComponent<levelController>().checkWinGame();

        if (winGame == true && level == currentLevel)
        {
            waitTimer += Time.deltaTime;
        }

        if(waitTimer >= waitTime)
        {
            waited = true;
        }

        if(waited == true)
        {
            rotatingBackgroundImage.enabled = true;
            rotatingBackgroundImage.GetComponent<rotatingImage>().startRotating();

            thisChildrenImage.enabled = true;
            GetComponentInChildren<Text>().enabled = true;
            regionUnlock.enabled = true;

            timer += Time.deltaTime;
        }

        if(timer > popupDuration)
        {
            rotatingBackgroundImage.enabled = false;
            thisChildrenImage.enabled = false;
            GetComponentInChildren<Text>().enabled = false;
            regionUnlock.enabled = false;
        }
    }
}
