using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotatingImage : MonoBehaviour
{
    public float rotateSpeed = 50f;
    public bool started;
    public bool reverse;

    // Update is called once per frame
    void Update()
    {
        if (started == true)
        {
            if(!reverse)
            {
                transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
            }

            else
            {
                transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
            }
        }
    }

    public void startRotating()
    {
        started = true;
    }
}
