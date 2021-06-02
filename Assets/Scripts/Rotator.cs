using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speedX = Random.Range(6.0f, 16.0f);
        float speedY = Random.Range(6.0f, 10.0f);
        float speedZ = Random.Range(4.0f, 8.0f);
        Vector3 speeds = new Vector3(speedX, speedY, speedZ);
        transform.Rotate(speeds * Time.deltaTime);
        
    }
}
