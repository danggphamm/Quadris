using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickTest : MonoBehaviour
{
    public GameObject sprite1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(sprite1, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0), Quaternion.identity);
        }
    }
}
