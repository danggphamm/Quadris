using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeController : MonoBehaviour
{
    // Main camera
    Camera mainCam;

    private float distanceBetweenNodes;

    // Number of neighbor with same color around
    public int numNeighbor;

    // If have this amount of same color node around, active the function combo
    public int neighborLimit = 4;

    // Hydrogen
    public Sprite atom;

    // Sun
    public Sprite sun;

    // BlackHole
    public Sprite blackhole;

    // Cell
    public Sprite cell;

    // Dinosaur
    public Sprite dinosaur;

    // Taco
    public Sprite taco;

    // Dolphin
    public Sprite dolphin;

    // Cat
    public Sprite cat;

    // Mermaid
    public Sprite mermaid;

    // Shark
    public Sprite shark;

    public Sprite nautilus;

    public Sprite ray;

    public Sprite squid;

    public Sprite chimaera;

    public Sprite octopus;

    public Sprite arthrodira;

    public Sprite helium;

    public Sprite meteor;

    public Sprite gasGiant;

    public List<Sprite> tier1Sprite = new List<Sprite>();
    public List<Sprite> tier2Sprite = new List<Sprite>();
    public List<Sprite> tier3Sprite = new List<Sprite>();

    bool gotCombo;

    SpriteRenderer hitNode;

    SpriteRenderer up;
    SpriteRenderer down;
    SpriteRenderer left;
    SpriteRenderer right;

    SpriteRenderer specialComboCenterSprite;

    int layerMask;

    // List to hold the expanded nodes
    private List<Transform> transformFrontier = new List<Transform>();

    private List<SpriteRenderer> sameColorNodes = new List<SpriteRenderer>();

    private List<SpriteRenderer> specialComboNodes = new List<SpriteRenderer>();

    public static List<GameObject> allNodes;

    private GameObject gridCreator;

    void Start()
    {
        gridCreator = GameObject.Find("Grid creator");
        allNodes = gridCreator.GetComponent<NodeSpawner>().getNodesList();

        distanceBetweenNodes = gridCreator.GetComponent<NodeSpawner>().distanceBetweenNodes;

        layerMask = ~LayerMask.GetMask("spriteSpawner");
        mainCam = Camera.main;
    }

    // Run every time mouse up
    public void check()
    {
        gotCombo = false;

        hitNode = GetComponent<SpriteRenderer>();

        for (int i = 0; i < 2; i ++)
        {
            checkSpecial();

            // Start with 1 neighbor with same color around (the node itself)
            numNeighbor = 1;

            // Clear the frontier - the list of expanded nodes
            transformFrontier.Clear();

            // The list that hold the nodes that have same color
            sameColorNodes.Clear();

            // Check the neighbors
            checkSameNeighbor(transform, hitNode.sprite);
        }

        checkSpecial();

        if (gotCombo == true)
        {
            int score = 0;
            if(tier2Sprite.Contains(hitNode.sprite))
            {
                mainCam.GetComponent<levelStats>().addTier2Point();
                score = mainCam.GetComponent<levelStats>().tier2Point;
            }

            else if(tier3Sprite.Contains(hitNode.sprite))
            {
                mainCam.GetComponent<levelStats>().addTier3Point();
                score = mainCam.GetComponent<levelStats>().tier3Point;
            }

            if(score > 0)
            {
                mainCam.GetComponent<levelStats>().showScore(hitNode.transform, score.ToString());
            }

            mainCam.GetComponent<levelController>().checkWinGame();
        }
    }

    // Check up, left, down, right neighbors
    private void checkSameNeighbor(Transform inputTransform, Sprite hitSprite)
    {
        // Add the node to the frontier
        transformFrontier.Add(inputTransform);

        RaycastHit2D hit;

        // Check up
        hit = Physics2D.Raycast(inputTransform.position + new Vector3(0, distanceBetweenNodes, 0), Vector2.up, 1f, layerMask);
        up = checkHitAndAssign(hit);
        checkNeighBor(up, hitSprite);

        // Check down
        hit = Physics2D.Raycast(inputTransform.position + new Vector3(0, -distanceBetweenNodes, 0), -Vector2.up, 1f, layerMask);
        down = checkHitAndAssign(hit);
        checkNeighBor(down, hitSprite);

        // Check right
        hit = Physics2D.Raycast(inputTransform.position + new Vector3(distanceBetweenNodes, 0, 0), Vector2.right, 1f, layerMask);
        right = checkHitAndAssign(hit);
        checkNeighBor(right, hitSprite);

        // Check left
        hit = Physics2D.Raycast(inputTransform.position + new Vector3(-distanceBetweenNodes, 0, 0), -Vector2.right, 1f, layerMask);
        left = checkHitAndAssign(hit);
        checkNeighBor(left, hitSprite);
    }

    // Check the node if its color is the same as the hit node
    private void checkNeighBor(SpriteRenderer inputSprite, Sprite hitSprite)
    {
        // Check for null exception and color similarity
        if (inputSprite != null && inputSprite.sprite == hitSprite)
        {
            // If currently not have enough 4 neighbors of same colors, continue checking the nodes around this node
            // Make sure that this node is not in the frontier, so we won't re-check it
            if (numNeighbor < neighborLimit && transformFrontier.Contains(inputSprite.transform) == false)
            {
                sameColorNodes.Add(inputSprite);
                numNeighbor++;
                checkSameNeighbor(inputSprite.transform, hitSprite);
            }

            // If already found 4 nodes with same colors
            if (numNeighbor >= neighborLimit)
            {
                // Turn all othes neighbor nodes with same color into white
                foreach (SpriteRenderer node in sameColorNodes)
                {
                    node.sprite = null;
                }

                if(hitSprite == atom)
                {
                    hitNode.sprite = sun;
                }

                else if (hitSprite == sun)
                {
                    hitNode.sprite = blackhole;
                }

                else if (hitSprite == cell)
                {
                    hitNode.sprite = dinosaur;
                }

                else if (hitSprite == dinosaur)
                {
                    hitNode.sprite = taco;
                }

                else if (hitSprite == dolphin)
                {
                    hitNode.sprite = cat;
                }

                else if (hitSprite == cat)
                {
                    hitNode.sprite = shark;
                }

                else if (hitSprite == ray)
                {
                    hitNode.sprite = chimaera;
                }

                else if (hitSprite == chimaera)
                {
                    hitNode.sprite = shark;
                }

                else if (hitSprite == nautilus)
                {
                    hitNode.sprite = squid;
                }

                else if (hitSprite == squid)
                {
                    hitNode.sprite = octopus;
                }

                else if (hitSprite == helium)
                {
                    hitNode.sprite = meteor;
                }

                else if (hitSprite == meteor)
                {
                    hitNode.sprite = gasGiant;
                }

                gotCombo = true;
            }
        }
    }

    // If hit an object, return its sprite renderer, else return null
    private SpriteRenderer checkHitAndAssign(RaycastHit2D hit)
    {
        SpriteRenderer inputSprite = null;
        if(hit.collider != null)
        {
            inputSprite = hit.collider.GetComponent<SpriteRenderer>();
        }

        return inputSprite;
    }

    public void checkSpecial()
    {
        int specialCombo = 0;

        foreach (GameObject node in allNodes)
        {
            int num = 1;
            if (node.GetComponent<SpriteRenderer>().sprite != null)
            {
                int score = 0;
                specialCombo = checkSpecialCombo(node.transform);
                if (specialCombo == 1)
                {
                    node.GetComponent<SpriteRenderer>().sprite = mermaid;
                    mainCam.GetComponent<levelStats>().addSpecialComboPoint(mainCam.GetComponent<levelStats>().getMermaidPoint());
                    score = mainCam.GetComponent<levelStats>().getMermaidPoint();
                    Debug.Log(score.ToString());
                }

                if (specialCombo == 2)
                {
                    node.GetComponent<SpriteRenderer>().sprite = arthrodira;
                    mainCam.GetComponent<levelStats>().addSpecialComboPoint(mainCam.GetComponent<levelStats>().getArthrodiraPoint());
                    score = mainCam.GetComponent<levelStats>().getArthrodiraPoint();
                }

                if(score > 0)
                {
                    mainCam.GetComponent<levelStats>().showScore(node.transform, score.ToString());
                }

                num++;
            }
        }
    }

    // Check for special combos
    public int checkSpecialCombo(Transform inputTransform)
    {
        specialComboNodes.Clear();

        // Combo 1
        if(
               ( checkNodeAt(inputTransform, dolphin, -1, 0)
              && checkNodeAt(inputTransform, cat, 0, 0)
              && checkNodeAt(inputTransform, dolphin, 1, 0))
          )
        {
            // Turn all othes neighbor nodes with same color into white
            foreach (SpriteRenderer node in specialComboNodes)
            {
                if(node!= null)
                {
                    node.sprite = null;
                }
            }

            return 1;
        }

        specialComboNodes.Clear();

        if (
                (checkNodeAt(inputTransform, dolphin, 0, -1)
              && checkNodeAt(inputTransform, cat, 0, 0)
              && checkNodeAt(inputTransform, dolphin, 0, 1)))
        {
            // Turn all othes neighbor nodes with same color into white
            foreach (SpriteRenderer node in specialComboNodes)
            {
                if (node != null)
                {
                    node.sprite = null;
                }
            }

            return 1;
        }

        specialComboNodes.Clear();

        // Combo 2
        if (checkNodeAt(inputTransform, shark, 0, 0)
          && checkNodeAt(inputTransform, chimaera, 1, 0)
          && checkNodeAt(inputTransform, chimaera, -1, 0)
          && checkNodeAt(inputTransform, chimaera, 0, 1)
          && checkNodeAt(inputTransform, chimaera, 0, -1))
        {
            // Turn all othes neighbor nodes with same color into white
            foreach (SpriteRenderer node in specialComboNodes)
            {
                if (node != null)
                {
                    node.sprite = null;
                }
            }

            return 2;
        }

        return 0;
    }

    private bool checkNodeAt(Transform inputTransform, Sprite inputSprite, int x, int y)
    {
        SpriteRenderer hitSprite = null;

        RaycastHit2D hit;

        hit = Physics2D.Raycast(inputTransform.position + new Vector3(distanceBetweenNodes * x, distanceBetweenNodes * y, 0), Vector2.up, 1f, layerMask);
        hitSprite = checkHitAndAssign(hit);
        specialComboNodes.Add(hitSprite);

        if(hitSprite == null)
        {
            return false;
        }

        if(hitSprite.sprite == inputSprite)
        {
            return true;
        }

        return false;
    }
}
