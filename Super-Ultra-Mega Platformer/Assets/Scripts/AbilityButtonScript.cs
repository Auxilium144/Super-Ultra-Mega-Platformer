using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButtonScript : MonoBehaviour {

	public Button ability1;
	public Button ability2;
	public Button ability3;
	public Button ability4;
	private int abilitiesCount;
	
	void Start () 
	{
		ability1 = ability1.GetComponent<Button> ();
		ability2 = ability2.GetComponent<Button> ();
		ability3 = ability3.GetComponent<Button> ();
		ability4 = ability4.GetComponent<Button> ();
		abilitiesCount = 0;
	}
	
	public void ability1Press()
	{
		if(abilitiesCount <= 2) 
		{
			
		}
		ability1.enabled = false;
	}
	
	public void ability2Press()
	{
		ability2.enabled = false;
	}
	
	public void ability3Press()
	{
		ability3.enabled = false;
	}
	
	public void ability4Press()
	{
		ability4.enabled = false;
	}
	
}
