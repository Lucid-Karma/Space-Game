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
	
    public static float forwardForce = 2000f;
	public float MoveSpeed = 500;
    public float RotSpeed = 100;

	//public static int point = 0;


    private void FixedUpdate()
    {
       //Rigidb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime);
       float VI = Input.GetAxis("Vertical") * RotSpeed;
       float HI = Input.GetAxis("Horizontal") * RotSpeed;
       transform.Rotate(VI, HI, 0 * RotSpeed * Time.fixedDeltaTime);

       if(Input.GetKey(KeyCode.X))
       {
           forwardForce = forwardForce + 2000f;
       }

       if(forwardForce >= 3000f || Input.GetKeyUp(KeyCode.X))
       {
           forwardForce = forwardForce - 800f;
       } 

	   Vector3 Posinput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
       //Vector3 Rotinput = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
	   
	   Rigidb.velocity = Posinput * MoveSpeed * Time.fixedDeltaTime; // velocity can cause problems in some case.	
       //Rigidb.AddForce(VI, HI, HI * forwardForce * Time.fixedDeltaTime);
       //transform.Translate(Posinput * MoveSpeed * Time.fixedDeltaTime);
       //transform.Rotate(VI, HI, 0 * RotSpeed * Time.fixedDeltaTime);	
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
