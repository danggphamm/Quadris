using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winPopup : MonoBehaviour
{
    Camera mainCam;

    public Transform thisObject;

    bool winGame = false;
    bool soundPlayed = false;

    public AudioClip completionSound;
    AudioSource speaker;


    // Start is called before the first frame update
    void Start()
    {
        thisObject.GetComponent<Image>().enabled = false;
        thisObject.GetComponentInChildren<Text>().enabled = false;
        mainCam = Camera.main;

        speaker = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        winGame = mainCam.GetComponent<levelController>().checkWinGame();

        if (winGame == true)
        {
            thisObject.GetComponent<Image>().enabled = true;
            thisObject.GetComponentInChildren<Text>().enabled = true;

            if(thisObject.GetComponent<AudioSource>() != null)
            {
                thisObject.GetComponent<AudioSource>().enabled = true;
            }

            if(soundPlayed == false && completionSound != null){
                speaker.PlayOneShot(completionSound, 0.5f);
                soundPlayed = true;
            }
        }
    }

    public void onEnable(){
        speaker.PlayOneShot(completionSound, 1);
    }
}
