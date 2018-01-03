using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

	public Camera camera1;
	public Camera camera2;
	public bool switchCam = false;

	void Start () 
	{
		camera1.GetComponent<Camera>().enabled = false;
		camera2.GetComponent<Camera>().enabled = true;
	}
	

	void Update () 
	{
		if (switchCam == true) 
		{
			camera1.GetComponent<Camera> ().enabled = true;
			camera2.GetComponent<Camera> ().enabled = false;
		} 

		else 
		{
			camera1.GetComponent<Camera>().enabled = false;
			camera2.GetComponent<Camera>().enabled = true;
		}
	}
}
