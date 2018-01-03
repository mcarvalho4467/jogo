using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExtraCountDown : MonoBehaviour {


	public Text CountDownText;
	public Text displayCountDown;
	public Vector2 position;

	private PlayerController playerposition;
	private float CountDown = 5;

	void Start ()
	{
		playerposition = FindObjectOfType<PlayerController> ();
	}

	void Update ()
	{
		if (CountDown > 0) 
		{
			CountDown -= Time.deltaTime; 
			CountDownText.text = "Time: " + CountDownText.ToString();
			displayCountDown.text = CountDown.ToString ("F0");
		} 

		if (CountDown <= 0) 
		{ 
			playerposition.speed = 0;
			playerposition.transform.position = new Vector2 (-75.4f, -6.9f);
			print (transform.position.y);

		}
	}
}
