using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour {

	public float vX = 2f;
	public float vZ = 0f;

	private Rigidbody2D rb2d;


	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}
	

	void Update () 
	{
		rb2d.velocity = new Vector2 (vX, vZ);
		Destroy (gameObject, 7f);
	}

}
