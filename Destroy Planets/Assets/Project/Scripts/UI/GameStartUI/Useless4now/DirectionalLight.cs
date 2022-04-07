using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalLight : MonoBehaviour
{
    public float xAxis;
    public float yAxis;
    
    public float speed;

    // Update is called once per frame
    void Update()
    {
        //speed = 50f;
        xAxis = Random.Range(-1f, 1f);
        yAxis = Random.Range(-1f,1f);
        transform.Rotate(xAxis * speed * Time.deltaTime, yAxis * speed * Time.deltaTime, 0, Space.Self);
    }
}
