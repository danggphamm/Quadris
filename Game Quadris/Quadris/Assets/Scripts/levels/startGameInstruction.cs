using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startGameInstruction : MonoBehaviour
{
    Image thisImage;
    public Text childText;

    public float popupDuration = 10f;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        thisImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > popupDuration)
        {
            thisImage.enabled = false;

            if(childText != null)
            {
                childText.enabled = false;
            }
        }
    }
}