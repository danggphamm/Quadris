using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backToOrigin : MonoBehaviour
{
    public Transform origin;

    public Sprite firstSprite;

    SpriteRenderer collidedNode;
    SpriteRenderer thisNode;
    Sprite savedSprite;

    public bool gameStarted = false;

    public List<Sprite> tier1Sprite = new List<Sprite>();

    public Sprite secretSprite;

    public List<Sprite> secrectSpriteList = new List<Sprite>();

    Camera mainCam;

    bool holding = false;

    void Start()
    {
        this.transform.position = new Vector3(origin.position.x, origin.position.y, origin.position.z);
        thisNode = GetComponent<SpriteRenderer>();

        if(firstSprite != null)
        {
            thisNode.sprite = firstSprite;
        }

        else
        {
            thisNode.sprite = tier1Sprite[(int)Random.Range(0, tier1Sprite.Count)];
        }
        
        mainCam = Camera.main;
        savedSprite = thisNode.sprite;
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
        if (holding == false && thisNode.sprite != null)
        {
            collidedNode = other.GetComponent<SpriteRenderer>();
            if(collidedNode.sprite == null)
            {
                if(gameStarted == false)
                {
                    gameStarted = true;
                    mainCam.GetComponent<levelStats>().startGame();
                }

                if(thisNode.sprite != secretSprite)
                {
                    collidedNode.sprite = thisNode.sprite;

                    thisNode.sprite = getRandomSprite();

                    other.GetComponent<NodeController>().check();
                }
                
                else
                {
                    collidedNode.sprite = getSecretSprite();

                    thisNode.sprite = getRandomSprite();

                    other.GetComponent<NodeController>().check();
                }
            }
        }
    }

    Sprite getRandomSprite()
    {
        Sprite randomSprite = tier1Sprite[(int)Random.Range(0, tier1Sprite.Count)];

        return randomSprite;
    }

    Sprite getSecretSprite()
    {
        Sprite returnSprite = secrectSpriteList[(int)Random.Range(0, secrectSpriteList.Count)];

        return returnSprite;
    }

    public void hide()
    {
        if (thisNode.sprite != null)
        {
            savedSprite = thisNode.sprite;
            thisNode.sprite = null;
        }
    }

    public void show()
    {
        thisNode.sprite = savedSprite;
    }
}

