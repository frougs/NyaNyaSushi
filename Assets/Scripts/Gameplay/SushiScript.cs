using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SushiScript : MonoBehaviour
{
   
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
