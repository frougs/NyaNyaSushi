using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PufferScript : MonoBehaviour
{
    private bool moving;
    private Rigidbody rb;
    private Vector3 objectUp;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        objectUp = transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        moving = GetComponent<ConveyorScript>().moving;
        if(moving){
            rb.AddForce(objectUp * 0.5f, ForceMode.Impulse);
        }
    }

   /*private void OnCollisionEnter(Collider other){
        if(other.)
    }*/
}
