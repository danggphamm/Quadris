using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class spriteMerging : MonoBehaviour
{
    public float speed = 10.0f;
    Transform goal;
    bool started = false;

    void Update()
    {
        if(started)
        {
            float step = speed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, goal.position, step);

            if (Vector2.Distance(transform.position, goal.position) < 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void activeAndSetGoal(Transform currentPosition, Transform goalPosition)
    {
        started = true;
        goal = goalPosition;
        transform.position = new Vector3(currentPosition.position.x, currentPosition.position.y, currentPosition.position.z);
    }
}
