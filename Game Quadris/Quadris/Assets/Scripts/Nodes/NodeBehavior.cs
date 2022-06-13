using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBehavior : MonoBehaviour
{
    int sameNeighbors;
    AudioSource sampleSound;
    SpriteRenderer render;
    BoxCollider2D collider;
    Collider2D target;
    Color transparent;
    Color white;
    Color blue;
    Color green;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        sampleSound = GetComponent<AudioSource>();
        transparent = Color.clear;
        white = Color.white;
        blue = Color.blue;
        green = Color.green;
        sameNeighbors = 0;

        if (this.CompareTag("Wall"))
        {
            render.color = transparent;
        }
        if (this.CompareTag("Node"))
        {
            render.color = white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
	
        if (this.CompareTag("Node"))
        {
            sampleSound.Play();
            render.color = blue;
            sameNeighbors++;
        }
	
        detectNeighbors();

	}

	private void detectNeighbors(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, 2, 0), Vector2.up);

        detectHit(hit, "above");

        hit = Physics2D.Raycast(transform.position + new Vector3(0, -2, 0), -Vector2.up);

        detectHit(hit, "below");

        hit = Physics2D.Raycast(transform.position + new Vector3(2, 0, 0), Vector2.right);

        detectHit(hit, "right");

        hit = Physics2D.Raycast(transform.position + new Vector3(-2, 0, 0), -Vector2.right);

        detectHit(hit, "left");

    }
    private void detectHit(RaycastHit2D hit, string direction){
        if(hit.collider != null){
            //Debug.Log("ping " + direction + "!" + hit.collider);

            SpriteRenderer targetSprite = hit.collider.GetComponent<SpriteRenderer>();

            //Debug.Log("Color: " + targetSprite.color);

            if(targetSprite.color != white){
                //sameNeighbors++;
                Debug.Log("same colors:" + sameNeighbors);
                //detectNeighbors();//causes an infinite loop, do not use
                checkForSame(hit, targetSprite);
            }


        }
    }
    private void checkForSame(RaycastHit2D hit, SpriteRenderer targetSprite){
        //RaycastHit2D check = Physics2D.Raycast(transform.position + new Vector3(0, 2, 0), Vector2.up);
        //check.collider.GetComponent<SpriteRenderer>()
        if(this.render.color == targetSprite.color){
            sameNeighbors++;
            Debug.Log("same colors:" + sameNeighbors);
        }else{
            //sameNeighbors = 0;
        }

        if(sameNeighbors >= 4){
            render.color = green;
            sameNeighbors = 0;
        }

        //check = Physics2D.Raycast(transform.position + new Vector3(0, -2, 0), -Vector2.up);

        //check = Physics2D.Raycast(transform.position + new Vector3(2, 0, 0), Vector2.right);

        //check = Physics2D.Raycast(transform.position + new Vector3(-2, 0, 0), -Vector2.right);

    }
}
