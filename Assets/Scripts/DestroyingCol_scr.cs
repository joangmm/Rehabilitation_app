using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingCol_scr : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Yellow" || other.tag == "Blue" || other.tag == "Green" || other.tag == "Red")
        {
            Destroy(other.gameObject);
        }
    
    }
}
