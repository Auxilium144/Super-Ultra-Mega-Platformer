using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Hud : MonoBehaviour {
	public Canvas abilityCanvas;
	private bool abilityCanvasOn = true;
	public Text abilityW;
	public Text abilityA;
	public Text abilityS;
	public Text abilityD;
	private string[] abilityNames = {"Double Jump", "Dash Forward", "Blink", "Float", "Bounce", "Wall Jump", "Wall Climb", "Heavy"};
	private string[] keyAbilities ={"No Ability", "No Ability", "No Ability", "No Ability"};
	private int[] abilityList = {-1, -1, -1, -1};
	Color oldColor;
	
	void Start () {
		getAbilityList();
		//int count = 0;
		int i = 0;
		while(i <= 3 && abilityList[i] != -1) {
			Debug.Log("--------------");
			Debug.Log("abilitylist[i] =" + abilityList[i]);
			Debug.Log("abilityNames[abilityList[i]] =" + abilityNames[abilityList[i]]);
			keyAbilities[i] = abilityNames[abilityList[i]];
			i++;
		}
		/*
		foreach(int i in abilityList) {
			keyAbilities[count] = abilityNames[abilityList[count]];
			count += 1;
		}
		*/
		if(abilityList[0] != -1) {
			abilityA.text = keyAbilities[0];
		}
		if(abilityList[1] != -1) {
			abilityS.text = keyAbilities[1];
		}
		if(abilityList[2] != -1) {
			abilityD.text = keyAbilities[2];
		}
		if(abilityList[3] != -1) {
			abilityW.text = keyAbilities[3];
		}
		oldColor = abilityA.color;
	}
	
	private void Update() 
	{
		
		if(CrossPlatformInputManager.GetButtonDown("Hide")) {
			Debug.Log("Hide");
			abilityCanvasOn = !abilityCanvasOn;
			abilityCanvas.GetComponent<Canvas> ().enabled = abilityCanvasOn;
			
		}
		if(abilityCanvasOn) {
			
			if(CrossPlatformInputManager.GetButtonDown("Ability0")) {
				abilityA.color = Color.white;
				abilityS.color = oldColor;
				abilityD.color = oldColor;
				abilityW.color = oldColor;
				
			}
			if(CrossPlatformInputManager.GetButtonDown("Ability1")) {
				abilityS.color = Color.white;
				abilityA.color = oldColor;
				abilityD.color = oldColor;
				abilityW.color = oldColor;
			}
			if(CrossPlatformInputManager.GetButtonDown("Ability2")) {
				abilityD.color = Color.white;
				abilityA.color = oldColor;
				abilityS.color = oldColor;
				abilityW.color = oldColor;
			}
			if(CrossPlatformInputManager.GetButtonDown("Ability3")) {
				abilityW.color = Color.white;
				abilityA.color = oldColor;
				abilityD.color = oldColor;
				abilityS.color = oldColor;
			}
		}
	}
	
	
	private void getAbilityList() 
	{
		string path = Directory.GetCurrentDirectory();
		string[] lines = System.IO.File.ReadAllLines(path + "abilities.txt");
		
		for (int i = 0; i <= 3 && (lines[i] != ""); i++) 
		{
				abilityList[i] = (int) Int32.Parse(lines[i]);
				Debug.Log("Stuff" + lines[i]);
		}
		
	}
	
}
