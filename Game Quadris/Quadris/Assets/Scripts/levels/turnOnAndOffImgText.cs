using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turnOnAndOffImgText : MonoBehaviour
{
    public void hideImg(Image img)
    {
        img.enabled = false;
    }

    public void hideText(Text txt)
    {
        txt.enabled = false;
    }
}
