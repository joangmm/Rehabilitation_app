using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls_Controller : MonoBehaviour
{
    public float speed = 30;
    private Vector3 dir;

    void Start(){
        float max, min = 0.0f;
        
        max = 0.1f;
        min = -0.1f;

        float rand_degree = Random.Range(max, min); //we compute a random degree for the ball to fall

        dir = new Vector3(rand_degree, - 1, 0);
        
    
        //podria añadir: con un chance del 20%, las bolas aparecen con un particle system de fuego y su speed es 45.
    
    }
    
    void Update(){

        transform.Translate(dir * speed * Time.deltaTime); //move the object into the pertinent direction

    }
}
