using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickHere : MonoBehaviour
{
    Image thisImage;
    public Text clickhereText;

    public float lowAlpha = 0.3f;
    public float highAlpha = 1f;
    public float changeRate = 0.0075f;
    int switcher = 0;
    Color helper;

    public float popupDuration = 10f;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        thisImage = GetComponent<Image>();
        helper = thisImage.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(switcher == 0)
        {
            helper.a -= changeRate;
            thisImage.color = helper;

            if(clickhereText != null)
            {
                clickhereText.color = helper;
            }

            if (helper.a < lowAlpha)
            {
                switcher = 1;
            }
        }

        else if(switcher == 1)
        {
            helper.a += changeRate;
            thisImage.color = helper;
            if (clickhereText != null)
            {
                clickhereText.color = helper;
            }

            if (helper.a >= highAlpha)
            {
                switcher = 0;
            }
        }

        timer += Time.deltaTime;

        if (timer > popupDuration)
        {
            thisImage.enabled = false;
            
            if(clickhereText != null)
            {
                clickhereText.enabled = false;
            }
        }
    }
}
