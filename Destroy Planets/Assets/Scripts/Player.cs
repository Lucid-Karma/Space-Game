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

	//public static int point = 0;



    public static float offset;
    public Transform Earth;


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

       //calculates the distance between player and planet. 
       offset = Vector3.Distance(transform.position, Earth.position);
       //Debug.Log("Distance  " + offset);	
    }

    void OnNeartoPlanet()
    {
        if (offset <= 20f)
        {
            EventManager.OnTargeting.Invoke();
            Debug.Log("Distance  " + offset);
        }
    }
}
