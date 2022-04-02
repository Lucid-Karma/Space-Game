using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCircling : MonoBehaviour
{
    Quaternion _newRotation;
    Vector3 _newPosition;
    private float counter;

    [SerializeField]
    [Range(0.01f, 0.1f)]
    private float lerpSpeed = 0.05f;

    private int radius = 10;
    private float distanceX;
    private float distanceZ;
    void FixedUpdate()
    {
        counter = Time.fixedDeltaTime * lerpSpeed;

        distanceX = Mathf.Cos(counter) * radius;
        distanceZ = Mathf.Sin(counter) * radius;


        _newPosition = new Vector3(distanceX, 0, distanceZ);
        transform.position = Vector3.Lerp(transform.position, _newPosition, Time.fixedDeltaTime * lerpSpeed);
        _newRotation = Quaternion.Euler(0, 270, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, _newRotation, Time.fixedDeltaTime * lerpSpeed);
    }

    /* thanks to Lerp, the movement is not like teleport:)
    ıt's slow it goes one by one in a nice way. position and rotation both.
    I needed sin and cos to know the distance from both x and z .. to make a circle road.
    radius is the distance from central of the world and the planet at the same time.
    */
}
