using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WristController : MonoBehaviour
{

    private string fruitNotToGrab;

    void Start()
    {

        fruitNotToGrab = FindObjectOfType<Game_Manager>().getColorNotToGrab();
        //here we will get the color that the player shouldn't touch.

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(fruitNotToGrab)) //if you touch a ball that is not the target color, the game substracts points.
        {

            //other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            FindObjectOfType<Game_Manager>().addWrong();

        }
        else if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Wall")){}
        else
        {
            Destroy(other.gameObject);
            FindObjectOfType<Game_Manager>().addCorrect();

        }
    }
    

}
