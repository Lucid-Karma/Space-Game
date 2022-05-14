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
	
    #region Movement
        //[Range(5f, 215f)]
        public static float thrust = 5f; //Forward force.
        public float lift; //Up and down movement.
        public float yaw; //Rotate of z axis?
        public float roll; //Left and right movement, Rotate from the nose?
        public float pitch; //Rotate of x axis.
        private float activeLift, activeYaw, activeRoll, activePitch;
        private float shipRange = 0.43f;


        /*
        public float activePitchMin, activePitchMax;
        public float activeYawMin, activeYawMax;
        public float activeRollMin, activeRollMax;
        */

        //private bool isLimitExceeded;


        //to draw the lines 
        public float xRange;
        public float yRange;
        public float zRange;

    #endregion

    #region Projectile
        public GameObject[] bullet; // Bullets here.
        private int bulletCount = 2;
        private bool swipe = true; // to control the loop.
    #endregion

    #region Raycast
        public RaycastHit celestialBodies; // This is our target. Gonna work just for planets cuz OnPlanetDestroy event called there and Kill method only works for this event.
        public Camera cockpit; // it is where do we aim.


        public ParticleSystem boomFlash;
    #endregion

    private void Awake() 
    {
        cockpit = GameObject.Find("Camera1").GetComponent<Camera>();

        // Make both of bullets not active so they will not be visible if they are not empty object or have MeshRenderer.
        for (int i = 0; i < bulletCount; i++)
        {
            bullet[i].SetActive(false);
        }

        //boomFlash.Stop();

         Physics.IgnoreLayerCollision(0, 7);
    }

    // Will only be triggered when the corresponding event is called.
    private void OnEnable()
    {
        EventManager.OnPreDestroy.AddListener(Kill);
        EventManager.OnRestart.AddListener(ResetSpeed);
        EventManager.OnCamera01On.AddListener(Invisible);
    }

    private void OnDisable()
    {
        EventManager.OnPreDestroy.RemoveListener(Kill);
        EventManager.OnRestart.RemoveListener(ResetSpeed);
        EventManager.OnCamera01On.RemoveListener(Invisible);
    }

    void Kill()
    {
        //Ray bulletWay = cockpit.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f));
        Ray bulletWay = cockpit.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(bulletWay, out celestialBodies, 1000f)) // (Our position?, target's position, 1000f away)
        {
            // These if statments provide to swipe bullets one by one from ship to the targets.
            if (swipe)
            {
                bullet[1].SetActive(false);
                bullet[1].transform.position = transform.position;
                bullet[0].SetActive(true);
                bullet[0].transform.position = celestialBodies.point;
                swipe = false;
            }
            else if(!swipe)
            {
                bullet[0].SetActive(false);
                bullet[0].transform.position = transform.position;
                bullet[1].SetActive(true);
                bullet[1].transform.position = celestialBodies.point;
                swipe = true;
            }
    
            boomFlash.transform.position = celestialBodies.point;
            boomFlash.Play();
        }
    }

    void ResetSpeed()
    {
        thrust = 5f;
    }

    void Invisible()
    {
        gameObject.GetComponent<MeshRenderer>().enabled=false;
    }
	
    private void FixedUpdate()
    {
       transform.position += transform.forward * thrust * Time.fixedDeltaTime;
       
       activePitch = Input.GetAxis("Vertical") * pitch * Time.fixedDeltaTime;
       activeYaw = Input.GetAxis("Horizontal") * yaw * Time.fixedDeltaTime;
       activeRoll = Input.GetAxis("Roll") * roll * Time.fixedDeltaTime;

       if(transform.localEulerAngles.x <= 290f && transform.localEulerAngles.x >= 60f)
            
            transform.Rotate(-Mathf.Sign(-activePitch), activeYaw, activeRoll, Space.Self);
        else
            transform.Rotate(-activePitch, activeYaw, activeRoll, Space.Self);

       /* 
       activePitch = Mathf.Clamp(activePitch, activePitchMin, activePitchMax);
       activeYaw = Mathf.Clamp(activeYaw, activeYawMin, activeYawMax);
       activeRoll = Mathf.Clamp(activeRoll, activeRollMin, activeRollMax);
       */
       //Quaternion target = Quaternion.Euler(-activePitch, activeYaw, activeRoll);
       //transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.fixedDeltaTime * pitch);
       /*if(transform.rotation.x <= shipRange && transform.rotation.x >= -shipRange) 
            transform.Rotate(-activePitch, activeYaw, -activeRoll, Space.Self);
       else if(transform.rotation.x >= shipRange)
       {
           transform.Rotate(0f, activeYaw, -activeRoll, Space.Self);
           Debug.Log(transform.rotation.x);
       }
            //transform.Rotate(shipRange, activeYaw, -activeRoll, Space.Self);
       else if(transform.rotation.x <= -shipRange)
       {
           transform.Rotate(-shipRange, activeYaw, -activeRoll, Space.Self);
           Debug.Log(transform.rotation.x);
       } */
            //transform.Rotate(-shipRange, activeYaw, -activeRoll, Space.Self);

       if(Input.GetKey(KeyCode.LeftShift) && thrust <= 92.5f)
       {
           //thrust = thrust + 2 * 8;
           thrust += 2.5f;

           //isSpeedDown = true;
       }
       else if(thrust >= 8f && Input.GetKey(KeyCode.LeftShift) == false)
       {
            thrust -= 3f;

            //isSpeedDown = false;
       }

       //if(thrust >= 400f || Input.GetKeyUp(KeyCode.X))
       /*if(Input.GetKey(KeyCode.LeftControl) && thrust >= 16.0f)
       {
           //if(thrust >= 16.0f)  thrust -= 15;
           //thrust = thrust / 2f;
           thrust -= 15;
       }*/ 

	   //Vector3 Posinput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
	   
	   //Rigidb.velocity = Posinput * MoveSpeed * Time.fixedDeltaTime; // velocity can cause problems in some case.

       WithinBoundary();
    }

    
    void WithinBoundary()
    {
        if(transform.position.x > xRange)
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        else if(transform.position.x < -xRange)
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);

        if(transform.position.y > yRange)
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        else if(transform.position.y < -yRange)
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);

        if(transform.position.z > zRange)
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        else if(transform.position.z < -zRange)
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
    }
    

    // If the ship hits something, calls the corresponding event
    private void OnCollisionEnter(Collision collision) 
    {
        if(PlanetsBase.isLevelSuccessed == false)
        {
            EventManager.OnLevelFail.Invoke();
            Debug.Log(collision.collider.name);
            Debug.Log("Player Collision");
        }
    }
}
