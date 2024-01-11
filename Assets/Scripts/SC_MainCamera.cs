using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MainCamera : MonoBehaviour
{
	private Transform player;
	private void Awake()
	{
		player = GameObject.FindWithTag("Player").transform;

	}

	private void LateUpdate()
	{
		Vector3 cameraPosition = transform.position;
		cameraPosition.x = player.position.x ;
		transform.position = cameraPosition;
	}

}
	