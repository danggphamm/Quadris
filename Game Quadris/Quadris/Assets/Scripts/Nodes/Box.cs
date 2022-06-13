using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private float startX;
    private float startY;
    private bool isBeingHeld = false;
    AudioSource dragSound;
    public AudioClip pickupSound;
    public AudioClip dropSound;
    private GameObject gridCreator;

    Camera mainCam;

    bool winGame = false;
    bool loseGame = false;

    void Start()
    {
        mainCam = Camera.main;

        gridCreator = GameObject.Find("Grid creator");

        if (GetComponent<AudioSource>() != null)
        {
            dragSound = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isBeingHeld == true)
        {
            Vector3 mousePos;

            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startX, mousePos.y - startY, -1);
        }

        // If won the level, can't drag and drop object anymore
        winGame = mainCam.GetComponent<levelController>().checkWinGame();

        loseGame = gridCreator.GetComponent<NodeSpawner>().CheckLoseGame();
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && winGame == false && loseGame == false)
        {
            if(dragSound != null)
            {
                dragSound.PlayOneShot(pickupSound, 1);
            }

            Vector3 mousePos;

            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startX = mousePos.x - this.transform.localPosition.x;
            startY = mousePos.y - this.transform.localPosition.y;

            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        if (dragSound != null)
        {
            dragSound.PlayOneShot(dropSound, 1);
        }

        isBeingHeld = false;
    }
}
