using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
    private float useSpeed;
    public float directionSpeed = 9.0f;
    float origin;
    public char axis;
    public float distance = 10.0f;

    // Use this for initialization
    void Start()
    {
        if (axis == 'y')
        {
            origin = transform.position.y;
            useSpeed = -directionSpeed;
        }
        else if (axis == 'x')
        {
            origin = transform.position.x;
            useSpeed = -directionSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (axis == 'y')
        {
            if (origin - transform.position.y > distance)
            {
                useSpeed = directionSpeed; //flip direction
            }
            else if (origin - transform.position.y < -distance)
            {
                useSpeed = -directionSpeed; //flip direction
            }
            transform.Translate(0, useSpeed * Time.deltaTime, 0);
        }
        else if (axis == 'x')
        {
            if (origin - transform.position.x > distance)
            {
                useSpeed = directionSpeed; //flip direction
            }
            else if (origin - transform.position.x < -distance)
            {
                useSpeed = -directionSpeed; //flip direction
            }
            transform.Translate(useSpeed * Time.deltaTime, 0, 0);
        }
    }
}