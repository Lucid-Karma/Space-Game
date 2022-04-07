using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffectMovement : MonoBehaviour
{

    #region CirclingAround
        [SerializeField] float speed = 0.1f;
        [SerializeField] float rot_T = 2.0f;
        [SerializeField] float rot_r = 10.0f;
        bool b_rot = false;

        void Update()
        {
            if(Input.GetKey (KeyCode.Space))
            {
                b_rot = true;
            }
            else
            {
                if (Input.GetKey (KeyCode.LeftArrow)) { this.transform.Translate (-speed, 0.0f, 0.0f); b_rot = false; }
                if (Input.GetKey (KeyCode.RightArrow)) { this.transform.Translate (speed, 0.0f, 0.0f); b_rot = false; }
                if (Input.GetKey (KeyCode.UpArrow)) { this.transform.Translate (0.0f, 0.0f, speed); b_rot = false; }
                if (Input.GetKey (KeyCode.DownArrow)) { this.transform.Translate (0.0f, 0.0f, -speed); b_rot = false; }
            }

            if(b_rot)
            {
                this.transform.position = new Vector3(rot_r * Mathf.Cos(2 * Mathf.PI * Time.time / rot_T), 2.0f, rot_r * Mathf.Sin(2 * Mathf.PI * Time.time / rot_T));
            }
        }
    #endregion

    #region goForwardNRotate
        /*
    public float speed;
    public float destroyTime;
    public float rotSpeed;
    float rotZ = 0;
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
       transform.position += transform.forward * Time.deltaTime * speed;

       rotZ += rotSpeed;
       transform.rotation = Quaternion.Euler(0, 0, rotZ); 
    }
    */
    #endregion
    
}
