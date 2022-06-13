using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eraser : MonoBehaviour
{
    public Transform origin;

    public int cost = 500;

    public bool gameStarted = false;

    public Text notEnoughPoint;

    SpriteRenderer collidedNode;

    Camera mainCam;

    bool holding = false;

    void Start()
    {
        this.transform.position = new Vector3(origin.position.x, origin.position.y, origin.position.z);

        mainCam = Camera.main;
    }

    void OnMouseDown()
    {
        holding = true;
    }

    void OnMouseUp()
    {
        holding = false;
        this.transform.position = new Vector3(origin.position.x, origin.position.y, origin.position.z);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (holding == false)
        {
            if(mainCam.GetComponent<levelStats>().score >= cost)
            {
                mainCam.GetComponent<levelStats>().subtractFromScore(cost);

                Debug.Log(mainCam.GetComponent<levelStats>().score);

                collidedNode = other.GetComponent<SpriteRenderer>();

                collidedNode.sprite = null;

                notEnoughPoint.GetComponent<popupText>().pop(other.transform, "-500");
            }
             
            
            else
            {
                collidedNode = other.GetComponent<SpriteRenderer>();

                if (collidedNode.sprite != null)
                {
                    notEnoughPoint.GetComponent<popupText>().pop(other.transform, "Not enough point!");
                }
            }
        }
    }
}
