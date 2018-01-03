using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public GameObject target;
	public float speed;
	public Rigidbody2D rb2d;

	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
	}
	

	void Update () 
	{
		rb2d.constraints = RigidbodyConstraints2D.FreezePositionX;
		transform.position = Vector3.MoveTowards (transform.position, target.transform.position, speed * Time.deltaTime);
		Vector3 vectorToTarget = target.transform.position - transform.position;
		float angle = Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		Quaternion qt = Quaternion.AngleAxis (angle, Vector3.forward);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, qt, Time.deltaTime * speed);
	}
}
