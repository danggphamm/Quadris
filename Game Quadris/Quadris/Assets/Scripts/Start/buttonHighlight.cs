using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class buttonHighlight : MonoBehaviour, IPointerEnterHandler, ISelectHandler, IPointerExitHandler
{
    public Image highlightImage;

    // Start is called before the first frame update
    void Start()
    {
        highlightImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //do your stuff when highlighted
        if(highlightImage != null)
        {
            highlightImage.enabled = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //do your stuff when stop highlighted
        if (highlightImage != null)
        {
            highlightImage.enabled = false;
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        //do your stuff when selected
    }
}
