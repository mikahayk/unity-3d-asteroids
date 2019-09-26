using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyByContact : MonoBehaviour
{
   

    void OnTriggerEnter(Collider other)
    {
        GameController myController = FindObjectOfType<GameController>();

        if (other.tag == "Player")
        {
            myController.GameOver();
            return;
        }

        if (other.tag == "Boundary")
        {
            return;
        }


        if (myController != null)
        {
            myController.AddScore(1);
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
        
    }

}