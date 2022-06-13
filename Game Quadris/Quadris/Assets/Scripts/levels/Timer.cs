using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    public Text bonus;
    int time = 0;
    Color originalColor;

    Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
        originalColor = timer.GetComponent<Text>().color;
    }

    // Update is called once per frame
    void Update()
    {
        time = (int) mainCam.GetComponent<levelStats>().timer;

        if(time > - 100f)
        {
            bonus.text = "Bonus: +" + mainCam.GetComponent<levelStats>().timeGoalBonusScore[mainCam.GetComponent<levelStats>().currentGoal].ToString();
            timer.text =  time.ToString();
        }

        else
        {
            timer.text = "";
            bonus.text = "Bonus: 0";
        }

        if(time <= 5)
        {
            timer.GetComponent<Text>().color = Color.red;
        }

        else
        {
            timer.GetComponent<Text>().color = originalColor;
        }
    }
}
