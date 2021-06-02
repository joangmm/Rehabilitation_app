using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls_Controller : MonoBehaviour
{
    public float speed;
    private Vector3 dir;

    private float startTime;
    private float timer;

    void Start(){
        float max, min = 0.0f;
        
        max = 0.1f;
        min = -0.1f;

        float rand_degree = Random.Range(max, min); 

        dir = new Vector3(rand_degree, - 1, 0);

        startTime = Random.Range(3.25f, 3.75f);
        speed = 42.5f;
        timer = 3.5f;
    }
    
    void Update(){
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World); //move the object into the pertinent direction

        if (timer <= 0)
        {
            //Debug.Log(speed);
            speed += 4.25f;
            timer = startTime;
        }

        else
        { //we didn't fulfill the counter yet: we keep substracting the counter
            timer -= Time.deltaTime;
        }
    }
}
