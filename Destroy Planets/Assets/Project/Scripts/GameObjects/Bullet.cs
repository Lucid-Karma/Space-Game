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

        if (Physics.Raycast(bulletWay, out celestialBodies, 500f))
        {
            Instantiate(bulletRB, cockpit.transform.position, Quaternion.identity);
            //transform.position = cockpit.transform.position;
            muzzleFlash.Play();
            transform.position = celestialBodies.point;
            //transform.position = cockpit.transform.position;
            //Debug.Log("success");
            Destroy(gameObject, 1.0f);

        }
    }
}
