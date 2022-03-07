using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{/*
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
	
    public static float forwardForce = 2000f;
	public float MoveSpeed = 500;

	//public static int point = 0;


    private void FixedUpdate()
    {
       Rigidb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime);

       if(Input.GetKey(KeyCode.X))
       {
           forwardForce = forwardForce + 2000f;
       }

       if(forwardForce >= 3000f || Input.GetKeyUp(KeyCode.X))
       {
           forwardForce = forwardForce - 800f;
       } 

	   Vector3 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
	   
	   Rigidb.velocity = input * MoveSpeed* Time.fixedDeltaTime; // velocity can cause problems in some case.		
    }*/



    public float speed;
    public float maxspeed;
    public float minspeed;
    public float rotspeed1;
    public float rotspeed2;


    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.W))
        {
            if (speed < maxspeed) speed++;
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (speed > minspeed) speed--;
        }

        speed -= transform.forward.y * Time.deltaTime * 50;
        if (speed < minspeed / 2) speed = minspeed;
        if (speed > maxspeed * 2) speed = maxspeed;

        
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate(Vector3.forward*Time.deltaTime*rotspeed1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.back * Time.deltaTime * rotspeed1);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * rotspeed1);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.left * Time.deltaTime * rotspeed1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * Time.deltaTime * rotspeed2);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.down * Time.deltaTime * rotspeed2);
        }

    }
}
