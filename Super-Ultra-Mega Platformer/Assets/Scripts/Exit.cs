using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


public class Exit : MonoBehaviour {
	public Button mainMenu;
    public Button backToGame;
	public Canvas exitCanvas;
	private bool exitCanvasOn = false;
	
	
	// Use this for initialization
	void Start () {
		exitCanvas.GetComponent<Canvas> ().enabled = exitCanvasOn;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			Debug.Log("Escape");
			exitCanvasOn = !exitCanvasOn;
			exitCanvas.GetComponent<Canvas> ().enabled = exitCanvasOn;
		}
	}
	public void backToGamePress() {
		exitCanvasOn = !exitCanvasOn;
		exitCanvas.GetComponent<Canvas> ().enabled = exitCanvasOn;
	}
	
	public void mainMenuPress() {
		SceneManager.LoadScene("menu");
	}
}
