using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Congrats : MonoBehaviour {


	public Text CountDownText;
	public Text displayCountDown;
	public Vector2 position;

	private float CountDown = 5;

	void Update ()
	{
		if (CountDown > 0) 
		{
			CountDown -= Time.deltaTime; 
			CountDownText.text = "Time: " + CountDownText.ToString();
			displayCountDown.text = CountDown.ToString ("F0");
		} 

	}
}
