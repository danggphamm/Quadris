using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelController : MonoBehaviour
{
    private bool isExtra;

    // To know which level is currently at
    int currentLevel;

    // Sprite 1
    public Sprite sprite1;

    // Sprite that merging srpite 1 makes
    public Sprite sprite1Supertype;

    // Sprite 1 goal
    public int sprite1Goal;

    // Sprite 2
    public Sprite sprite2;

    // Sprite that merging srpite 2 makes
    public Sprite sprite2Supertype;

    // Sprite 2 goal
    public int sprite2Goal;

    // Sprite 3
    public Sprite sprite3;

    // Sprite that merging srpite 2 makes
    public Sprite sprite3Supertype;

    // Sprite 3 goal
    public int sprite3Goal;

    Camera mainCam;

    private GameObject gridCreator;

    private static List<GameObject> allNodes;

    void Start()
    {
        mainCam = Camera.main;

        isExtra = mainCam.GetComponent<levelStats>().isExtra;
        gridCreator = GameObject.Find("Grid creator");
        allNodes = gridCreator.GetComponent<NodeSpawner>().getNodesList();

        currentLevel = GetComponent<levelStats>().level;
    }

    public bool checkWinGame()
    {
        bool won = false;

        int numSprite1 = 0;
        int numSprite2 = 0;
        int numSprite3 = 0;

        foreach (GameObject node in allNodes)
        {
            if (node.GetComponent<SpriteRenderer>().sprite != null)
            {
                if (node.GetComponent<SpriteRenderer>().sprite == sprite1)
                {
                    numSprite1++;
                }

                if (node.GetComponent<SpriteRenderer>().sprite == sprite1Supertype)
                {
                    numSprite1 += 4;
                }

                if (node.GetComponent<SpriteRenderer>().sprite == sprite2)
                {
                    numSprite2++;
                }

                if (node.GetComponent<SpriteRenderer>().sprite == sprite2Supertype)
                {
                    numSprite2 += 4;
                }

                if (node.GetComponent<SpriteRenderer>().sprite == sprite3)
                {
                    numSprite3++;
                }

                if (node.GetComponent<SpriteRenderer>().sprite == sprite3Supertype)
                {
                    numSprite3 += 4;
                }
            }
        }

        if (numSprite1 >= sprite1Goal
        && numSprite2 >= sprite2Goal
        && numSprite3 >= sprite3Goal)
        {
            won = true;

            if (!isExtra)
            {
                GetComponent<GameController>().incrementCurrentLevel(currentLevel);
            }
        }

        return won;
    }
}
