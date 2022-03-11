using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer1 : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void FixedUpdate()
    {
        transform.position = player.position + offset;
        transform.rotation = player.rotation;
    }
}
