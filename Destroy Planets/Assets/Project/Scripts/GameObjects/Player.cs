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
        
        public float thrust = 500; //Forward force.
        public float lift; //Up and down movement.
        public float yaw; //Left and right movement, Rotate from the nose.
        public float roll; //Rotate of z axis.
        public float pitch; //Rotate of x axis.
        private float activeLift, activeYaw, activeRoll, activePitch;

    #endregion

    #region Projectile
        public GameObject[] bullet; // Bullets here.
        private int bulletCount = 2;
        private bool swipe = true; // to control the loop.
    #endregion

    #region Raycast
        public RaycastHit celestialBodies; // This is our target. Gonna work just for planets cuz OnPlanetDestroy event called there and Kill method only works for this event.
        public Camera cockpit; // it is where do we aim.
    #endregion

    private void Awake() 
    {
        cockpit = GameObject.Find("Camera1").GetComponent<Camera>();

        // Make both of bullets not active so they will not be visible if they are not empty object or have MeshRenderer.
        for (int i = 0; i < bulletCount; i++)
        {
            bullet[i].SetActive(false);
        }
    }

    // Will only be triggered when the corresponding event is called.
    private void OnEnable()
    {
        EventManager.OnPlanetDestroy.AddListener(Kill);
    }

    private void OnDisable()
    {
        EventManager.OnPlanetDestroy.RemoveListener(Kill);
    }

    void Kill()
    {
        Ray bulletWay = cockpit.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f));

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
        }
    }
	

    private void FixedUpdate()
    {
       transform.position += transform.forward * thrust * Time.fixedDeltaTime;

       activePitch = Input.GetAxis("Vertical") * pitch * Time.fixedDeltaTime;
       activeRoll = Input.GetAxis("Horizontal") * roll * Time.fixedDeltaTime;
       activeYaw = Input.GetAxis("Yaw") * yaw * Time.fixedDeltaTime;

       transform.Rotate(-activePitch, activeYaw, -activeRoll, Space.Self);

       if(Input.GetKey(KeyCode.X))
       {
           thrust = thrust * 2f;
       }

       //if(thrust >= 400f || Input.GetKeyUp(KeyCode.X))
       if(Input.GetKey(KeyCode.Z))
       {
           thrust = thrust / 2f;
       } 

	   //Vector3 Posinput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
	   
	   //Rigidb.velocity = Posinput * MoveSpeed * Time.fixedDeltaTime; // velocity can cause problems in some case.
    }

    // If the ship hits something, calls the corresponding event
    private void OnCollisionEnter(Collision other) 
    {
        EventManager.OnLevelFail.Invoke();
        Debug.Log("touched");
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
