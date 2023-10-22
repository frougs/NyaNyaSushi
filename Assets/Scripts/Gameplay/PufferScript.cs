using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PufferScript : MonoBehaviour
{
    private bool canJump;
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
        if(canJump){
            rb.AddForce(objectUp * 0.15f, ForceMode.Impulse);
        }
    }

   /*private void OnCollisionEnter(Collider other){
        if(other.)
    }*/

    private void OnTriggerEnter(Collider other){
        if(other.GetComponent<Collider>().gameObject.tag == "Conveyor"){
            canJump = true;
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.GetComponent<Collider>().gameObject.tag == "Conveyor"){
            canJump = false;
        }
    }
}
