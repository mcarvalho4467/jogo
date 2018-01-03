using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

	public string menu;

	public void QuitToMenu ()
	{
		SceneManager.LoadScene ("Menu");
	}


}
