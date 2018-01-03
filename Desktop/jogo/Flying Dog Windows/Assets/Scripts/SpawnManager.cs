using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public GameObject bomb;
	Vector2 spawnPoint;
	public float spawnRate = 2f;
	public float nextSpawn = 1f;

	void Update () 
	{
		if (Time.time > nextSpawn) 
		{
			nextSpawn = Time.time + spawnRate;
			spawnPoint = new Vector2 (transform.position.x, transform.position.y);
			Instantiate (bomb, spawnPoint, Quaternion.identity);
		}
	}
}
