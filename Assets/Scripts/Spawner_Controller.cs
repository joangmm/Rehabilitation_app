using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Controller : MonoBehaviour
{

    private float startTime;
    private float timer;
    public GameObject[] balls;

    private void Start()
    {
        startTime = Random.Range(8.25f, 8.75f); //0.5f;
        timer = 1.5f;
    }
    private void Update(){

        
        
        if(timer <=0){ //if the counter is 0, we instantiate with a 50% chance

            //Debug.Log(startTime);

            int rand = Random.Range(0, balls.Length);
            Instantiate(balls[rand], transform.position, Quaternion.identity);
            timer = startTime;
            Move();

            if(startTime >= 8.8f)
            {
                startTime -= 0.55f;
            }
            if (startTime >= 6.05f)
            {
                startTime -= 0.35f;
            }
            else if (startTime >= 6.2f)
            {
                startTime -= 0.12f;
            }
            else if (startTime >= 4.6f)
            {
                startTime -= 0.055f;
            }
            else if (startTime >= 2.8f)
            {
                startTime -= 0.01f;
            }
            else {}
        }
        
        else{ //we didn't fulfill the counter yet: we keep substracting the counter
            timer -= Time.deltaTime;
        }
    }
    public void Move(){
        float rnd = Random.Range(-375, 350); //x-axis goes from -375 to 350 (limits of the physical movement in the tracking system)
        transform.position = new Vector3( rnd, transform.position.y, transform.position.z);
    }


}
