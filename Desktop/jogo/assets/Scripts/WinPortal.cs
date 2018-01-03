using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPortal : MonoBehaviour {

	public GameObject winPanel;

	private AudioSource audio;
	private PlayerController player;
	private ScoreManager sm;

	void Awake ()
	{
		player = FindObjectOfType<PlayerController> ();
		sm = FindObjectOfType<ScoreManager> ();
	}

	void Start ()
	{
		audio = GetComponent<AudioSource> ();
		winPanel.SetActive (false);
	}

	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.tag == "Player") 
		{ 
			Win ();
	    }
}

	public void Win ()
	{
		sm.pointsPerSecond = 0;
		winPanel.SetActive (true);
		sm.finalCount = sm.scoreCount + sm.EyeCount;
	}
}
