using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textColorChanging : MonoBehaviour
{
    public float changingRate = 0.5f;
    float timer = 0f;

    void Start()
    {
        GetComponent<Text>().color = Color.yellow;
    }

        // Update is called once per frame
        void Update()
    {
        timer += Time.deltaTime;

        if(timer >= changingRate)
        {
            timer = 0f;

            if(GetComponent<Text>().color == Color.red)
            {
                GetComponent<Text>().color = Color.yellow;
            }

            else if (GetComponent<Text>().color == Color.yellow)
            {
                GetComponent<Text>().color = Color.red;
            }
        }
    }
}
