using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {
	public Text abilityW;
	public Text abilityA;
	public Text abilityS;
	public Text abilityD;
	private string[] abilityNames = {"Double Jump", "Dash Forward", "Blink", "Lunge", "Bounce", "Wall Jump", "Wall Climb"};
	private string[] keyAbilities ={"No Ability", "No Ability", "No Ability", "No Ability"};
	private int[] abilityList = {-1, -1, -1, -1};
	
	void Start () {
		getAbilityList();
		int count = 0;
		foreach(int i in abilityList) {
			keyAbilities[count] = abilityNames[abilityList[count]];
			count += 1;
		}
		// Below are not the correct number assignments
		abilityW.text = keyAbilities[3];
		//abilityA = GetComponent<Text>();
		abilityA.text = keyAbilities[0];
		//abilityS = GetComponent<Text>();
		abilityS.text = keyAbilities[1];
		//abilityD = GetComponent<Text>();
		abilityD.text = keyAbilities[2];
	}
	
	
	private void getAbilityList() 
	{
		string path = Directory.GetCurrentDirectory();
		string[] lines = System.IO.File.ReadAllLines(path + "abilities.txt");
		for (int i = 0; i <= 3; i++) 
		{
			abilityList[i] = Int32.Parse(lines[i]);
			Debug.Log("Stuff" + lines[i]);
		}
		
	}
}
