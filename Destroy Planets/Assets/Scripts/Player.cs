using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidb;
	public Rigidbody Rigidb 
	
	{
        get
        {
            if(rigidb == null)
			{
				rigidb = GetComponent<Rigidbody>();
			}

            return rigidb;
        }
    }
	
	public float thrust = 500; //Forward force.
    public float lift; //Up and down movement.
    public float yaw; //Left and right movement, Rotate from the nose.
    public float roll; //Rotate of z axis.
    public float pitch; //Rotate of x axis.
    private float activeLift, activeYaw, activeRoll, activePitch;


    private void FixedUpdate()
    {
       transform.position += transform.forward * thrust * Time.fixedDeltaTime;

       activePitch = Input.GetAxis("Vertical") * pitch * Time.fixedDeltaTime;
       //activeRoll = Input.GetAxis("Horizontal") * roll * Time.fixedDeltaTime;
       activeYaw = Input.GetAxis("Horizontal") * yaw * Time.fixedDeltaTime;

       transform.Rotate(-activePitch, activeYaw, -activeRoll, Space.Self);

       if(Input.GetKey(KeyCode.X))
       {
           thrust = thrust * 2f;
       }

       if(thrust >= 3000f || Input.GetKeyUp(KeyCode.X))
       {
           thrust = thrust / 2f;
       } 

	   //Vector3 Posinput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
	   
	   //Rigidb.velocity = Posinput * MoveSpeed * Time.fixedDeltaTime; // velocity can cause problems in some case.
    }


/*
    public float speed;
    public float maxspeed;
    public float minspeed;
    public float rotspeed1;
    public float rotspeed2;


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.forward * Time.fixedDeltaTime * speed;

        if (Input.GetKey(KeyCode.W))
        {
            if (speed < maxspeed) speed++;
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (speed > minspeed) speed--;
        }

        speed -= transform.forward.y * Time.fixedDeltaTime * 10;
        if (speed < minspeed / 2) speed = minspeed;
        if (speed > maxspeed * 2) speed = maxspeed;

        
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate(-Vector3.up * Time.fixedDeltaTime * rotspeed2);
            transform.Translate(Vector3.left*Time.fixedDeltaTime*rotspeed1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.down * Time.fixedDeltaTime * rotspeed2);
            transform.Translate(Vector3.right * Time.fixedDeltaTime * rotspeed1);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.left * Time.fixedDeltaTime * rotspeed1);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.right * Time.fixedDeltaTime * rotspeed1);
        }*/

        /*if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * Time.fixedDeltaTime * rotspeed2);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.down * Time.fixedDeltaTime * rotspeed2);
        }

    }*/
}
