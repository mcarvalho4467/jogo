using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject gameOverPanel;
	public bool isDead;

	private AudioSource deathAudio;
	private PauseController pause;
	private ScoreManager sm;

	void Start ()
	{
		deathAudio = GetComponent<AudioSource>();
		pause = FindObjectOfType<PauseController> ();
		sm = FindObjectOfType <ScoreManager> ();
	}

	void Awake ()
	{
		gameOverPanel.SetActive (false);
		isDead = false;
	}

	void Update () 
	{

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") 
		{
			if (!isDead) 
			{
				gameOverPanel.SetActive (true);
				sm.scoreIncreasing = false;
				Time.timeScale = 0;
				deathAudio.Play ();
				sm.finalCount = sm.scoreCount + sm.EyeCount;
				Death ();

			}

		
		}

		if (other.gameObject.transform.parent) 
		{
			Destroy (other.gameObject.transform.parent.gameObject);
			Death ();
		}

		else 
		{
			Destroy (other.gameObject);
		}
			
	}

	public void Death ()
	{
		isDead = true;
		pause.paused = true;
	}

		
}
