using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelStats : MonoBehaviour
{
    public Text popScore;
    public int score = 0;
    private int totalScore = 0;
    public int level;
    public bool isExtra;
    public bool endless;
    public int tier2Point = 50;
    public int tier3Point = 70;
    public int tier4Point = 200;
    public int mermaidPoint = 100;
    public int arthrodiraPoint = 200;
    public int dinacoPoint = 300;

    bool gameStarted = false;

    public float timer = 0.0f;

    public int[] timeGoalBonusScore = { 40, 20, 10 };

    public int[] timeGoal = { 15, 30, 60 };

    public int currentGoal;

    public int bonus = 0;

    bool addedBonus = false;

    Camera mainCam;

    GameObject gridCreator;

    bool winGame = false;

    void Start()
    {
        gridCreator = GameObject.Find("Grid creator");
        mainCam = Camera.main;
        currentGoal = 0;
        timer = timeGoal[currentGoal];
    }

    // Update is called once per frame
    void Update()
    {
        winGame = mainCam.GetComponent<levelController>().checkWinGame();

        if (winGame == true && addedBonus == false)
        {
            if(timer > -1f)
            {
                bonus = timeGoalBonusScore[currentGoal];
            }

            totalScore = score + bonus;

            addedBonus = true;
        }

        if (gameStarted == true && winGame == false)
        {
            timer -= Time.deltaTime;
        }

        if(timer <= 0f)
        {
            if(currentGoal < timeGoal.Length - 1)
            {
                currentGoal++;
                timer = timeGoal[currentGoal] - timeGoal[currentGoal - 1];
            }

            else
            {
                timer = -100f;
                bonus = 0;
            }
        }

        if(endless && gridCreator.GetComponent<NodeSpawner>().CheckLoseGame() == true)
        {
            totalScore = score;
        }

        if (!isExtra)
        {
            if (level == 1 && totalScore > GameController.playerData.level1HighScore)
            {
                GameController.playerData.level1HighScore = totalScore;
                SaveAndLoad.Save();
            }

            else if (level == 2 && totalScore > GameController.playerData.level2HighScore)
            {
                GameController.playerData.level2HighScore = totalScore;
                SaveAndLoad.Save();
            }

            else if (level == 3 && totalScore > GameController.playerData.level3HighScore)
            {
                GameController.playerData.level3HighScore = totalScore;
                SaveAndLoad.Save();
            }

            else if (level == 4 && totalScore > GameController.playerData.level4HighScore)
            {
                GameController.playerData.level4HighScore = totalScore;
                SaveAndLoad.Save();
            }

            else if (level == 5 && totalScore > GameController.playerData.level5HighScore)
            {
                GameController.playerData.level5HighScore = totalScore;
                SaveAndLoad.Save();
            }

            else if (level == 6 && totalScore > GameController.playerData.level6HighScore)
            {
                GameController.playerData.level6HighScore = totalScore;
                SaveAndLoad.Save();
            }

            else if (level == 7 && totalScore > GameController.playerData.level7HighScore)
            {
                GameController.playerData.level7HighScore = totalScore;
                SaveAndLoad.Save();
            }

            else if (level == 8 && totalScore > GameController.playerData.level8HighScore)
            {
                GameController.playerData.level8HighScore = totalScore;
                SaveAndLoad.Save();
            }

            else if (level == 9 && totalScore > GameController.playerData.level9HighScore)
            {
                GameController.playerData.level9HighScore = totalScore;
                SaveAndLoad.Save();
            }
        }

        else
        {
            if (level == 4 && totalScore > GameController.playerData.extra1HighScore)
            {
                GameController.playerData.extra1HighScore = totalScore;
                SaveAndLoad.Save();
            }

            if (level == 7 && totalScore > GameController.playerData.extra2HighScore)
            {
                GameController.playerData.extra2HighScore = totalScore;
                SaveAndLoad.Save();
            }

            if (level == 10 && totalScore > GameController.playerData.extra3HighScore)
            {
                GameController.playerData.extra3HighScore = totalScore;
                SaveAndLoad.Save();
            }

            if (level == 13 && totalScore > GameController.playerData.endlessHighScore)
            {
                GameController.playerData.endlessHighScore = totalScore;
                SaveAndLoad.Save();
            }
        }
    }

    public void addTier2Point()
    {
        score += tier2Point;
    }

    public void addTier3Point()
    {
        score += tier3Point;
    }

    public void addTier4Point()
    {
        score += tier4Point;
    }

    public void addSpecialComboPoint(int inputPoint)
    {
        score += inputPoint;
    }

    public void showScore(Transform inputTransform, string inputString)
    {
        popScore.GetComponent<popupScore>().pop(inputTransform, inputString);
    }

    public int getMermaidPoint()
    {
        return mermaidPoint;
    }

    public int getArthrodiraPoint()
    {
        return arthrodiraPoint;
    }

    public int getDinacoPoint()
    {
        return dinacoPoint;
    }

    public void startGame()
    {
        gameStarted = true;
    }

    public void subtractFromScore(int amount)
    {
        score -= amount;
    }
}
