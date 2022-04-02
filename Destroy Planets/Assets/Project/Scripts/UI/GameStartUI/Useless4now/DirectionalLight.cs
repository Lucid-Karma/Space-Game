using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalLight : MonoBehaviour
{
    public float xAxis;
    public float yAxis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Random.Range(0f, 1f);
        //yAxis = Random.Range(-3.0f,3f);
        transform.rotation = new Quaternion(xAxis, 0, 0, 1);
    }
}
