using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SushiScript : MonoBehaviour
{
   

    private int score;

    void Start()
    {
        
    }

    void Update()
    {

    }


   private void OnCollisionEnter(Collision collision)
   {
        if(collision.gameObject.tag == "Knife")
        {
            Destroy(gameObject);
            
        }
   }
}
