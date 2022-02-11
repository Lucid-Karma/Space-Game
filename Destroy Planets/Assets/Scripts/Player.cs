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
	
    public float forwardForce = 2000f;
	public float MoveSpeed;

	public static int point = 0;


    private void FixedUpdate()
    {
       Rigidb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime);

       if(Input.GetKey(KeyCode.X))
       {
           forwardForce = forwardForce + 200f;
       }

       if(forwardForce >= 3000f || Input.GetKeyUp(KeyCode.X))
       {
           forwardForce = forwardForce - 10f;
       } 

	   Vector3 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
	   
	   Rigidb.velocity = input * MoveSpeed* Time.fixedDeltaTime; // velocity can cause problems in some case.		
    }
}
