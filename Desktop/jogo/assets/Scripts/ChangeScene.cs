using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ChangeScene : MonoBehaviour {

	private AudioSource audio;
	public bool nextscene;

	[SerializeField] private string loadLevel;

	void Start ()
	{
		audio = GetComponent<AudioSource> ();
		nextscene = false;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) 
		{
			SceneManager.LoadScene (loadLevel);
			audio.Play ();
			nextscene = true;
		}

	}
}
