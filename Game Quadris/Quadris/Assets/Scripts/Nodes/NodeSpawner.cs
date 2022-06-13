using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSpawner : MonoBehaviour
{
    bool waiting = false;

    Sprite helperSprite;

    float newSpriteTimer = 0f;
    float waitingTime = 2f;

    int chosenNode;

    public GameObject node;
    public GameObject nodeBackground;
    public GameObject newSpriteAnimation;

    GameObject objectHolder;

    public int[] removeNodes = new int[20];

    public int width = 3;
    public int height = 3;
    public float distanceBetweenNodes;
    public float xOrigin = 0;
    public float yOrigin = 0;

    private List<GameObject> allNodes = new List<GameObject>();
    private List<GameObject> emptyNodes = new List<GameObject>();

    // Create the grid
    void Start()
    {
        int index = 1;
        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j ++)
            {
                if(contains(index, removeNodes) == false)
                {
                    GameObject newNode = Instantiate(node, new Vector3(xOrigin + distanceBetweenNodes * j,
                                                  yOrigin - distanceBetweenNodes * i, 0), Quaternion.identity);
                    allNodes.Add(newNode);

                    Instantiate(nodeBackground, new Vector3(xOrigin + distanceBetweenNodes * j,
                                                  yOrigin - distanceBetweenNodes * i, 0), Quaternion.identity);
                }

                index++;
            }
        }
    }

    public List<GameObject> getNodesList()
    {
        return allNodes;
    }

    bool contains(int val, int[] array)
    {
        foreach(int i in array)
        {
            if (i == val)
            {
                return true;
            }
        }

        return false;
    }

    public bool CheckLoseGame()
    {
        bool isLost = true;
        foreach(GameObject node in allNodes)
        {
            if(node.GetComponent<SpriteRenderer>().sprite == null)
            {
                isLost = false;
            }
        }

        return isLost;
    }

    public void spawnNewSprite(Sprite inputSprite)
    {
        chosenNode = -1;
        newSpriteTimer = 0f;
        waiting = true;
        helperSprite = inputSprite;

        emptyNodes.Clear();

        foreach (GameObject node in allNodes)
        {
            if (node.GetComponent<SpriteRenderer>().sprite == null)
            {
                emptyNodes.Add(node);
            }
        }

        chosenNode = (int)Random.Range(0, emptyNodes.Count);

        Transform helper = emptyNodes[chosenNode].transform;

        objectHolder = Instantiate(newSpriteAnimation, new Vector3(helper.position.x, helper.position.y, helper.position.z), Quaternion.identity);
    }

    void Update()
    {
        if(waiting)
        {
            newSpriteTimer += Time.deltaTime;

            if(newSpriteTimer >=waitingTime && chosenNode >= 0)
            {
                waiting = false;
                Destroy(objectHolder);

                if (emptyNodes.Count > 0)
                {
                    emptyNodes[chosenNode].GetComponent<SpriteRenderer>().sprite = helperSprite;
                }
            }
        }
    }
}
