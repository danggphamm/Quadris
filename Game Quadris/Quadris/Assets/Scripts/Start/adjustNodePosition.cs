using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adjustNodePosition : MonoBehaviour
{
    public GameObject Node1;
    public float posX;
    public float posY;

    private float distancesBetweeNodes = 55f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Node1 != null)
        {
            transform.position = new Vector3(Node1.transform.position.x + posX * distancesBetweeNodes,
                                                       Node1.transform.position.y + posY * distancesBetweeNodes,
                                                       Node1.transform.position.z);
        }
    }
}
