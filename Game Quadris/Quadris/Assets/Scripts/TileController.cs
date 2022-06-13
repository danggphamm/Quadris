using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Things to check for later: Overlap methods for composite collider*/
public class TileController : MonoBehaviour
{
    CompositeCollider2D comp;
    Rigidbody2D rigid2D;
    Color blue;
    // Start is called before the first frame update
    void Start()
    {
        comp = GetComponent<CompositeCollider2D>();
        //rigid2D = GetComponent<Rigidbody2D>();
        rigid2D = comp.attachedRigidbody;
        blue = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //Destroy(this);
        Debug.Log("Mouse Down!");
    }
}
