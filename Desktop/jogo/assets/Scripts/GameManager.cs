using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject gameOverPanel;
	public AudioSource deathAudio;
	public GameObject particle;

	private PauseController pause;
	private ScoreManager sm;
	private PlayerController player;

	void Start ()
	{
		deathAudio = GetComponent<AudioSource>();
		pause = FindObjectOfType<PauseController> ();
		sm = FindObjectOfType <ScoreManager> ();
		player = FindObjectOfType <PlayerController> ();
	}
		
	void Awake ()
	{
		gameOverPanel.SetActive (false);
		particle.SetActive (false);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			gameObject.GetComponent<Renderer> ().enabled = false;
			deathAudio.Play ();
			player.takedamage = true;
			particle.SetActive (true);
		}			
	}

	public void Death ()
	{
		sm.pointsPerSecond = 0;
		gameOverPanel.SetActive (true);
		sm.finalCount = sm.scoreCount + sm.EyeCount;
		pause.paused = true;
	}

		
}
