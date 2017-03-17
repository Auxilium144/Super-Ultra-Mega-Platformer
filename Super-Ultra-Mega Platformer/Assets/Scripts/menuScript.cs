using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuScript : MonoBehaviour {

	public Button scene1Text;
	public Button exit;

	void Start () {
		scene1Text = scene1Text.GetComponent<Button> ();
		exit = exit.GetComponent<Button> ();
	}
	
	public void scene1Press()
	{
		Application.LoadLevel(1);
	}
	
	public void exitPress()
	{
		 Application.Quit();
	}
}
