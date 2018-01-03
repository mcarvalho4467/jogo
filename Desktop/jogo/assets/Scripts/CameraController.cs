using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public PlayerController player;

	private Vector3 lastPlayerPosition;
	private float distanceToMove;

	void Start ()
	{
		player = FindObjectOfType<PlayerController> ();
	}

	void Update ()
	{
		distanceToMove = player.transform.position.x - lastPlayerPosition.x;
		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y, transform.position.z);
		lastPlayerPosition = player.transform.position;
	}
}
