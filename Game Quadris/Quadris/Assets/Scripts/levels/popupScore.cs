using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popupScore : MonoBehaviour
{
    bool started = false;
    public float popupSpeed = 0.05f;
    public float existingDistance = 3f;
    float distance = 0f;

    void Start()
    {
        GetComponent<Text>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(started)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + popupSpeed, 0);
            distance += popupSpeed;
        }

        if (distance > existingDistance)
        {
            GetComponent<Text>().text = "";
            started = false;
            distance = 0f;
        }
    }

    public void pop(Transform inputTransform, string inputText)
    {
        GetComponent<Text>().text = "+" + inputText;
        transform.position = new Vector3(inputTransform.position.x, inputTransform.position.y + popupSpeed, transform.position.z);
        started = true;
    }
}
