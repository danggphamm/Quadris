using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelHighScoreDisplayer : MonoBehaviour
{
    public GameObject thisGlobe;
    private int level;
    public Text thisText;
    public bool isExtra;
    private bool endless;
    private int[] highScoresList;
    private int[] specialHighScoresList;
    private int endlessHighScore;

    void Start()
    {
        level = thisGlobe.GetComponent<changeLockedSprite>().levelNumber;
        endless = thisGlobe.GetComponent<changeLockedSprite>().endless;
        endlessHighScore = GameController.playerData.endlessHighScore;

        if (!isExtra)
        {
            highScoresList = new int[100];
            highScoresList[0] = GameController.playerData.level1HighScore;
            highScoresList[1] = GameController.playerData.level2HighScore;
            highScoresList[2] = GameController.playerData.level3HighScore;
            highScoresList[3] = GameController.playerData.level4HighScore;
            highScoresList[4] = GameController.playerData.level5HighScore;
            highScoresList[5] = GameController.playerData.level6HighScore;
            highScoresList[6] = GameController.playerData.level7HighScore;
            highScoresList[7] = GameController.playerData.level8HighScore;
            highScoresList[8] = GameController.playerData.level9HighScore;
        }

        else
        {
            specialHighScoresList = new int[100];
            specialHighScoresList[0] = GameController.playerData.extra1HighScore;
            specialHighScoresList[1] = GameController.playerData.extra2HighScore;
            specialHighScoresList[2] = GameController.playerData.extra3HighScore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!isExtra)
        {
            thisText.text = "High score: " + highScoresList[level - 1].ToString();
        }

        else
        {
            if(!endless)
            {
                thisText.text = "High score: " + specialHighScoresList[level / 3 - 1].ToString();
            }

            else
            {
                thisText.text = "High score: " + endlessHighScore;
            }
        }
    }
}
