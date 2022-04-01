using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer1 : MonoBehaviour
{
    public Transform player; //Get player's position values.
    public Vector3 offset; //Get a variable to specify the camera's distance to the player.

    void FixedUpdate()
    {
        transform.position = player.position + offset;
        transform.rotation = player.rotation;
    }
}
