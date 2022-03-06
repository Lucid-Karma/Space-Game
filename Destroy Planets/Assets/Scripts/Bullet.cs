using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRB;
    public RaycastHit celestialBodies;
    public Camera cockpit;
    public ParticleSystem muzzleFlash;

    private void Awake() 
    {
        bulletRB = GetComponent<Rigidbody>();   
        cockpit = GameObject.Find("Camera1").GetComponent<Camera>();
    }
    /*void Start()
    {
        float speed = 100f;
        bulletRB.velocity = transform.forward * speed;
    }*/

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
        //Vector3 shoot = new Vector3(0.5f, 0.5f, 0);
        //float speed = 100f;
        //bulletRB.velocity = transform.position(Input.mousePosition) * speed;
        //bulletRB.transform.position = shoot;
        //Destroy(gameObject, 2f);

        Ray bulletWay = cockpit.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f));

        if (Physics.Raycast(bulletWay, out celestialBodies, 500f))
        {
            muzzleFlash.Play();
            transform.position = celestialBodies.point;
            Debug.Log("success");
        }
    }

    
}
