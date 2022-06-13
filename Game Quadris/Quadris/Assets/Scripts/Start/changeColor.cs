using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeColor : MonoBehaviour
{
    Image thisNode;
    float timer = 0f;
    public float changeRate = 1f;
    public Sprite blue;
    public Sprite green;
    public Sprite purple;
    public Sprite orange;
    public Sprite pink;
    public Sprite red;
    public Sprite yellow;

    // Start is called before the first frame update
    void Start()
    {
        thisNode = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= changeRate)
        {
            timer = 0f;
            thisNode.sprite = changeSprite(thisNode.sprite);
        }
    }

    Sprite changeSprite(Sprite inputSprite)
    {
        if (inputSprite == blue)
        {
            return purple;
        }

        else if (inputSprite == purple)
        {
            return pink;
        }

        else if (inputSprite == pink)
        {
            return red;
        }

        else if (inputSprite == red)
        {
            return orange;
        }

        else if (inputSprite == orange)
        {
            return yellow;
        }

        else if (inputSprite == yellow)
        {
            return green;
        }

        else
            return blue;
    }
}
