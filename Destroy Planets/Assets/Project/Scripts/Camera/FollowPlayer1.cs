using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer1 : MonoBehaviour
{
    public Transform player; //Get player's position values.
    public Vector3 offset; //Get a variable to specify the camera's distance to the player.


    public float lift; //Up and down movement.
    public float yaw; //Rotate of z axis?
    public float roll; //Left and right movement, Rotate from the nose?
    public float pitch; //Rotate of x axis.
    private float activeLift, activeYaw, activeRoll, activePitch;

    void FixedUpdate()
    {
        transform.position = player.position + offset;
        //transform.rotation = player.rotation;

        activePitch = Input.GetAxis("Vertical") * pitch * Time.fixedDeltaTime;
        activeYaw = Input.GetAxis("Horizontal") * yaw * Time.fixedDeltaTime;
        activeRoll = Input.GetAxis("Roll") * roll * Time.fixedDeltaTime;

        transform.Rotate(-activePitch, activeYaw, -activeRoll, Space.Self);
    }
}
