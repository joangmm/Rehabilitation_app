using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Controller : MonoBehaviour
{

    private float startTime = 0.1f; //CHANGE THIS VALUE TO 6.55f
    private float timeBtwSpawn;
    public GameObject[] balls;
    private void Update(){
        if(timeBtwSpawn <=0){ //if the counter is 0, we instantiate with a 50% chance

            //we could directly instantiate a ball now, but to make the game fairer, we will create a boolean variable
            if(Random.Range(0, 2) == 1) {
                //and the 50% of the times will enter here, where we will add 2 more seconds (we won't spawn for now)
                timeBtwSpawn += 0.5f; /////////////////////////////////////////////CHANGE THIS VALUE TO 1.0F
            }
            else{ //the rest 50% of the times, we will directly instantiate the ball.
                int rand = Random.Range(0, balls.Length);
                Instantiate(balls[rand], transform.position, Quaternion.identity);
                timeBtwSpawn = startTime;
                Move();
            }
        }
        else{ //we didn't fulfill the counter yet: we keep substracting the counter
            timeBtwSpawn -= Time.deltaTime;
        }
    }
    public void Move(){
        float rnd = Random.Range(-375, 350); //x-axis goes from -280 to 130 (limits of the physical movement in the tracking system)
        transform.position = new Vector3( rnd, transform.position.y, transform.position.z);
    }


}
