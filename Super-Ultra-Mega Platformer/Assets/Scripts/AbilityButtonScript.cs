using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class AbilityButtonScript : MonoBehaviour {

	public Button ability1;
	public Button ability2;
	public Button ability3;
	public Button ability4;
	public Button ability5;
	public Button ability6;
	public Button ability7;
	private int abilitiesCount;
	private string[] abilities;
	string path;
	
	void Start () 
	{
		ability1 = ability1.GetComponent<Button> ();
		ability2 = ability2.GetComponent<Button> ();
		ability3 = ability3.GetComponent<Button> ();
		ability4 = ability4.GetComponent<Button> ();
		ability5 = ability5.GetComponent<Button> ();
		ability6 = ability6.GetComponent<Button> ();
		ability7 = ability7.GetComponent<Button> ();
		
		abilitiesCount = 0;
		abilities = new string[4];
		path = Directory.GetCurrentDirectory();
	}
	
	public void ability1Press()
	{
		abilityHandler("1");
		ability1.enabled = false;
	}
	
	public void ability2Press()
	{
		abilityHandler("2");
		ability2.enabled = false;
	}
	
	public void ability3Press()
	{
		abilityHandler("3");
		ability3.enabled = false;
	}
	
	public void ability4Press()
	{
		abilityHandler("4");
		ability4.enabled = false;
	}
	
	public void ability5Press()
	{
		abilityHandler("5");
		ability5.enabled = false;
	}
	
	public void ability6Press()
	{
		abilityHandler("6");
		ability6.enabled = false;
	}
	
	public void ability7Press()
	{
		abilityHandler("7");
		ability7.enabled = false;
	}
	
	private void abilityHandler(string ability) 
	{
		if(abilitiesCount <= 2) 
		{
			abilities[abilitiesCount] = ability;
			abilitiesCount++;
		}
		else 
		{
			abilities[abilitiesCount] = ability;
			System.IO.File.WriteAllLines(path + "abilities.txt", abilities);
			Application.LoadLevel (2);
		}
	}
}
