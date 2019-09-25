using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPositioner : MonoBehaviour
{
    public float actualSpeed = 10.0f;
    public GameObject[] checkpoints;
    int counter = 0;
    public float distance = 2.0f; //on which distance you want to switch to the next waypoint
    private Vector3 direction;

    void FixedUpdate()
    {
        direction = Vector3.zero;
        //get the vector from your position to current waypoint
        direction = checkpoints[counter].transform.position - transform.position;
        //check our distance to the current waypoint, Are we near enough?
        if (direction.magnitude < distance)
        {
            if (counter < checkpoints.Length - 1) //switch to the nex waypoint if exists
            {
                counter++;
            }
            else //begin from new if we are already on the last waypoint
            {
                counter = 0;
            }
        }
        direction = direction.normalized;
        Vector3 dir = direction;

        GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * actualSpeed, direction.y * actualSpeed);
    }
}