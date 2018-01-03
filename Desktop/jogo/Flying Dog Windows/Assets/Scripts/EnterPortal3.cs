using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterPortal3 : MonoBehaviour {

	public GameObject extra3;
	public GameObject cam1;
	public GameObject cam2;
	public Text CountDownText;
	public Text displayCountDown;
	public float cdown = 30;

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
		extra3.SetActive (false);
		cam1.SetActive (true);
		cam2.SetActive (false);
	}

	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.tag == "Player") 
		{ 
			audio.Play ();
			InvokeRepeating ("CountDown", 1, 1);
			this.enabled = false;
			player.speed = 0f;
			player.transform.position = new Vector2 (1070, -26f);
			extra3.SetActive (true);
			sm.pointsPerSecond = 0;
			cam1.SetActive (false);
			cam2.SetActive (true);
		}
	}

	public void CountDown ()
	{
		if (cdown > 0) 
		{
			cdown--;
			cdown -= Time.deltaTime; 
			CountDownText.text = "Time: " + CountDownText.ToString();
			displayCountDown.text = cdown.ToString ("F0");
		} 

		if (cdown <= 0) 
		{ 
			Destroy (GameObject.FindWithTag ("SpawnPoint"));
			CancelInvoke ();
			cam1.SetActive (true);
			cam2.SetActive (false);
			extra3.SetActive (false);
			sm.pointsPerSecond = 4f;
			player.speed = 6f;
			sm.bonusCount = sm.bonusCount + 250;
			sm.SetBonus ();
			player.transform.position = new Vector2 (1083, -3f);

		}
	}

}
