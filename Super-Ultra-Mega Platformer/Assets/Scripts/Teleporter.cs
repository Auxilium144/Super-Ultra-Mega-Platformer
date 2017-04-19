using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Teleporter : MonoBehaviour {

    private float Origin1x;
    private float Origin1y;
    private float Origin2x;
    private float Origin2y;
    GameObject Entrance = null;
    GameObject Exit = null;
    public int timer = 0;
    public int timermax = 600;
    public int triggered = 0;
    private BoxCollider2D[] Boxes = new BoxCollider2D[2];

    // Use this for initialization
    void Start ()
    {
        Entrance = transform.Find("TeleportEntrance").gameObject;
        Exit = transform.Find("TeleportExit").gameObject;
        if(Entrance != null)
        {
            Origin1x = Entrance.transform.position.x - this.transform.position.x;
            Origin1y = Entrance.transform.position.y - this.transform.position.y - 0.5f;
            Debug.Log("recorded origin 0");
            Debug.Log(Entrance.transform.position);
        }
        if (Exit != null)
        {
            Origin2x = Exit.transform.position.x - this.transform.position.x;
            Origin2y = Exit.transform.position.y - this.transform.position.y - 0.5f;
            Debug.Log("record origin 1");
            Debug.Log(Exit.transform.position);
        }

        Boxes = gameObject.GetComponents<BoxCollider2D>();
        if (Entrance != null && Exit != null)
        {
            if (Boxes[0] != null)
            {
                Boxes[0].offset = new Vector2(Origin1x, Origin1y);
                Debug.Log("Changed box 0");
            }
            if (Boxes[1] != null)
            {
                Boxes[1].offset = new Vector2(Origin2x, Origin2y);
                Debug.Log("Changed box 1");
            }
            /*if(Boxes[0] != null && Boxes[1] != null)
            {
                //transform.parent = otherObject.transform;
                Boxes[0].transform.parent = this.transform;
                Boxes[1].transform.parent = this.transform;
                Debug.Log("yes");
            }*/
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (timer > 0)
        {
            timer = timer - 1;
        }
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Entrance == null && Exit == null)
            {
                Debug.Log("Teleporters don't exist");
            }
            else if(Entrance != null && Exit != null && timer < 1)
            {

                float tempx1 = Math.Abs(other.transform.position.x - Entrance.transform.position.x);
                float tempy1 = Math.Abs(other.transform.position.y - Entrance.transform.position.y);
                float tempx2 = Math.Abs(other.transform.position.x - Exit.transform.position.x);
                float tempy2 = Math.Abs(other.transform.position.y - Exit.transform.position.y);
                if ((tempx1 > tempx2) && (tempy1 > tempy2))
                {
                    Debug.Log("At Teleporter1");
                    other.transform.position = Entrance.transform.position;
                    timer = timermax;
                    triggered = triggered + 1;
                }
                else if ((tempx1 < tempx2) && (tempy1 < tempy2))
                {
                    Debug.Log("At Teleporter2");
                    other.transform.position = Exit.transform.position;
                    timer = timermax;
                    triggered = triggered + 1;
                }
                //Debug.Log("Teleporter Exist");
                
                /*Debug.Log("temp1 teleporter2");
                Debug.Log(tempx1);
                Debug.Log(tempy1);
                Debug.Log("temp2 teleport1");
                Debug.Log(tempx2);
                Debug.Log(tempy2);*/
            }
            else { }
            
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Entrance == null && Exit == null)
            {
                Debug.Log("Teleporters don't exist and left the teleport zone");
            }
            else if (Entrance != null && Exit != null)
            {
                Debug.Log("Teleporter Exist and left the teleporter");
            }
            else { }

        }
    }
}
