using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour {

	public bool grounded;
	public LayerMask WhatIsGround;
	public float  jumpForce;
	public float jumpTime;
	public float jumpTimeCounter;
	public Collider2D collider;
	public float speed;
	public float speedMultiplier;
	public float speedIncreaseMilestone;

	private float speedMilestoneCount;
	private Rigidbody2D rb2d;
	private bool canDJump;
	private AudioSource audioSource;
	private PauseController pause;
	private ScoreManager sm;
	private GameManager gm;
	private AudioSource audio;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		collider = GetComponent<Collider2D> ();
		speedMilestoneCount = speedIncreaseMilestone;
		jumpTimeCounter = jumpTime;
		audioSource = GetComponent<AudioSource>();
		pause = FindObjectOfType<PauseController> ();
		sm = FindObjectOfType <ScoreManager> ();
		gm = FindObjectOfType<GameManager> ();
		audio = GetComponent<AudioSource> ();
	}

	void Update ()
	{
		if (pause.paused) 
		{
			return;
		}

		grounded = Physics2D.IsTouchingLayers (collider, WhatIsGround);
		rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);


		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			if (grounded) 
			{
				rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpTime);
			}

			if (!grounded && canDJump) 
			{
				canDJump = false;
				rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpTime);
				jumpTimeCounter = jumpTime;
			}

		}

		if (Input.GetKey (KeyCode.Space))
			{
				if (jumpTimeCounter > 0) 
				{
					rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpForce);
					jumpTimeCounter -= Time.deltaTime;
				}
			}

		if (Input.GetKeyUp (KeyCode.Space)) 
		{
			jumpTimeCounter = 0;
		}

		if (grounded) 
		{
			jumpTimeCounter = jumpTime;
			canDJump = true;
		}

		if (transform.position.x > speedMilestoneCount) 
		{
			speedMilestoneCount += speedIncreaseMilestone;
			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
			speed = speed * speedMultiplier;
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			sm.EyeCount = sm.EyeCount + 25;
			sm.SeteyeCount ();
			audioSource.Play();
		}

	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag.Equals ("Bomb"))
		{
			other.gameObject.SetActive (false);
			audio.Play ();
			gm.Death ();
			gm.gameOverPanel.SetActive (true);
		}
	}
}
