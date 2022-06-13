using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeLockedSprite : MonoBehaviour
{
    public Sprite spriteToChangeTo;
    public int levelNumber;
    public Text highScore;
    public bool endless;

    void Start()
    {
        highScore.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.playerData.currentLevel >= levelNumber)
        {
            this.GetComponent<Image>().sprite = spriteToChangeTo;
            highScore.enabled = true;
        }

        if(endless && GameController.playerData.currentLevel >= 10)
        {
            this.GetComponent<Image>().sprite = spriteToChangeTo;
            highScore.enabled = true;
        }
    }
}
