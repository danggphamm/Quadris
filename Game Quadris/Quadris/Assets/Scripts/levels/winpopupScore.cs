using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winpopupScore : MonoBehaviour
{
    public Text score;
    Camera mainCam;
    private int total;

    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        total = mainCam.GetComponent<levelStats>().score + mainCam.GetComponent<levelStats>().bonus;
        score.text = "YOU WIN!\n\n" + "Your score: " + mainCam.GetComponent<levelStats>().score.ToString() 
            + "\n\nBonus: " + mainCam.GetComponent<levelStats>().bonus.ToString()
            + "\n\nTotal: " + total.ToString();
    }
}
