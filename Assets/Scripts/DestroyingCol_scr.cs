using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingCol_scr : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "apple" || other.tag == "orange" || other.tag == "watermelon" || other.tag == "carrot")
        {
            Destroy(other.gameObject);
        }
    
    }
}
