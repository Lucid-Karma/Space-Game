using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public static FollowPlayer Instance { get; private set; }

	public Transform target;

	public float distance = 6f;
	public float elevation = 5f;

	private void Awake()
	{
		if( Instance == null )
			Instance = this;
		else if( this != Instance )
		{
			Destroy( this );
			return;
		}
	}

	private void FixedUpdate()
	{
		Vector3 targetPosition = target.position - target.forward * distance + new Vector3( 0f, elevation, 0f );

		transform.localPosition = Vector3.Slerp( transform.localPosition, targetPosition, 0.1f );

		Quaternion rot = Quaternion.LookRotation( target.position - transform.localPosition );
		transform.localRotation = Quaternion.Slerp( transform.localRotation, rot, 0.1f );
	}
}
