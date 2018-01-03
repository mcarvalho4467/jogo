using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour {
 
	public GameObject pausePanel;
	public bool paused;

	private ScoreManager scoreManager;

	void Awake ()
	{
		pausePanel.SetActive (false);
	}

	void Start ()
	{
		paused = false;
		scoreManager = FindObjectOfType<ScoreManager> ();
	}

	void Update ()
	{
		if (paused) 
		{
			OnPause ();
		}

		else
		{
			OnUnPause ();
		}
			
	}
		

	public void OnPause ()
	{
		scoreManager.scoreIncreasing = false;
		pausePanel.SetActive (true);
		paused = true;
		Time.timeScale = 0;
	}

	public void OnUnPause ()
	{
		scoreManager.scoreIncreasing = true;
		pausePanel.SetActive (false);
		paused = false;
		Time.timeScale = 1;
	}
		
}