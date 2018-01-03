using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text score;
	public Text highScore;
	public Text finalScore;
	public float scoreCount;
	public float highScoreCount;
	public float finalCount;
	public float pointsPerSecond;
	public bool scoreIncreasing;
	public Text eyeT;
	public float EyeCount;
	public Text bonus;
	public float bonusCount;

	private PauseController pause;

	void Start () 
	{
		pause = FindObjectOfType<PauseController> ();
		SeteyeCount ();
		EyeCount = 0;
		bonusCount = 0;
		SetBonus ();

		if (PlayerPrefs.HasKey ("High Score")) 
		{
			highScoreCount = PlayerPrefs.GetFloat ("High Score");
		}
	}

	void Update () 
	{
		if (pause.paused) 
		{
			return;
		}

		if (scoreCount + EyeCount + bonusCount > highScoreCount) 
		{
			highScoreCount = scoreCount + EyeCount + bonusCount;
			PlayerPrefs.SetFloat ("High Score",highScoreCount);
		}

		if (scoreIncreasing) 
		{
			scoreCount += pointsPerSecond * Time.deltaTime;
			Time.timeScale = 1;
			scoreIncreasing = true;
		} 

		score.text = "Score: " + Mathf.Round (scoreCount);
		highScore.text = "High Score: " + Mathf.Round (highScoreCount);
		finalScore.text = "Final Score: " + Mathf.Round (scoreCount + EyeCount + bonusCount);
	}

	public void SeteyeCount ()

	{
		eyeT.text = "Eyes: " + EyeCount.ToString ();
	}

	public void SetBonus ()
	{
			bonus.text = "Bonus: " + bonusCount.ToString ();
	}
}
