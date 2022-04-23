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
        
        public static float thrust = 5f; //Forward force.
        public float lift; //Up and down movement.
        public float yaw; //Rotate of z axis?
        public float roll; //Left and right movement, Rotate from the nose?
        public float pitch; //Rotate of x axis.
        private float activeLift, activeYaw, activeRoll, activePitch;

        private bool isLimitExceeded;

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
    }

    // Will only be triggered when the corresponding event is called.
    private void OnEnable()
    {
        EventManager.OnPreDestroy.AddListener(Kill);
    }

    private void OnDisable()
    {
        EventManager.OnPreDestroy.RemoveListener(Kill);
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
	

    private void FixedUpdate()
    {
       transform.position += transform.forward * thrust * Time.fixedDeltaTime;

       activePitch = Input.GetAxis("Vertical") * pitch * Time.fixedDeltaTime;
       activeYaw = Input.GetAxis("Horizontal") * yaw * Time.fixedDeltaTime;
       activeRoll = Input.GetAxis("Roll") * roll * Time.fixedDeltaTime;
       

       transform.Rotate(-activePitch, activeYaw, -activeRoll, Space.Self);

       if(Input.GetKey(KeyCode.X))
       {
           //thrust = thrust + 2 * 8;
           thrust += 10;
       }

       //if(thrust >= 400f || Input.GetKeyUp(KeyCode.X))
       if(Input.GetKey(KeyCode.Z))
       {
           if(thrust >= 16.0f)  thrust -= 15;
           //thrust = thrust / 2f;
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
}
