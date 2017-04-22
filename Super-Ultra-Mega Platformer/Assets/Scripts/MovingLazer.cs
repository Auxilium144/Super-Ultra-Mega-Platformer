using UnityEngine;
using System.Collections;

public class MovingLazer : MonoBehaviour
{
    private float useSpeed;
    public float directionSpeed = 9.0f;
    float originx;
    float originy;
    public char axis;
    public int direction;
    public float distance = 10.0f;
    public int timerMax;
    private int timer;

    // Use this for initialization
    void Start()
    {

            originy = transform.position.y;
            originx = transform.position.x;
        if (direction > 0)
        {
            useSpeed = -directionSpeed;
        }
        else
        {
            useSpeed = directionSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (axis == 'y')
        {
            if (direction > 0)//if going up
            {
                if (originy - transform.position.y < distance)//going up!
                {
                    useSpeed = -directionSpeed; //go
                }
                else if (originy - transform.position.y > -distance)
                {
                    transform.position = new Vector2(originx, originy); //return home
                    timer = timerMax;//respawn time
                }              
            }
            else if (direction < 0)
            {
                if (originx - transform.position.y > distance)//going down
                {
                    useSpeed = directionSpeed; //go
                }
                else if (originx - transform.position.y < -distance)
                {
                    transform.position = new Vector2(originx, originy); //return home
                    timer = timerMax;//respawn time
                }
            }

            if (timer < 1)
            {
                transform.Translate(0, useSpeed * Time.deltaTime, 0);// go
            }
            else
            {
                timer = timer - 1; //start waiting
            }
        }
        else if (axis == 'x')
        {
            if (direction > 0)//if going left
            {
                if (originx - transform.position.x < distance)
                {
                    useSpeed = -directionSpeed; //flip direction
                }
                else if (originx - transform.position.x > -distance)
                {
                    transform.position = new Vector2(originx, originy); //return home
                    timer = timerMax;//repsawn time
                }
            }
            else if (direction < 0)//if going right
            {
                if (originx - transform.position.x > distance)//move right until distance
                {
                    useSpeed = directionSpeed; //go
                }
                else if (originx - transform.position.x < -distance)//bring you back to spawn point
                {
                    transform.position = new Vector2(originx, originy); //return home
                    timer = timerMax;//respawn time
                }
            }
            if (timer < 1)
            {
                transform.Translate(useSpeed * Time.deltaTime, 0, 0);// go
            }
            else
            {
                timer = timer - 1; //start waiting
            }
        }
    }
}