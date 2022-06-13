using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBackground : MonoBehaviour
{
    public Transform thisNode;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(thisNode.position.x, thisNode.position.y, 2);
    }
}
