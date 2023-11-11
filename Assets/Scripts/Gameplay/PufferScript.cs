using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PufferScript : MonoBehaviour
{
    public float pufferSpeed = 0.3f;

    private void FixedUpdate(){
        var currentPos = this.transform.position;
        currentPos.z -= pufferSpeed * Time.deltaTime;
        transform.position = currentPos;
    }

































    //
    //IGNORE SAVED JUST IN CASE:
    //


   /* private bool canJump;
    private Rigidbody rb;
    private Vector3 objectUp;
    private Vector3 pufferPos;
    private ConveyorScript conveyor;
    OrderScript orders;
    private float pufferJump = 5;
    private float gravity = -9.81f;
    float velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        objectUp = transform.up;
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        orders = FindObjectOfType<OrderScript>();
        conveyor = GetComponent<ConveyorScript>();
    }

    // Update is called once per frame
    void Update()
    {
       pufferPos = transform.position;
        pufferPos.x = Mathf.Clamp(transform.position.x, 0f, 0f);
        pufferPos.z -= ((conveyor.sushiSpeed * orders.orderNumber) - conveyor.endlessAdjustment) * Time.deltaTime;
        //velocity += gravity * Time.deltaTime;
        //if(canJump){
            velocity = pufferJump;
        //}
        //transform.Translate(new Vector3(0, velocity, pufferPos.z) * Time.deltaTime);




        speed = conveyor.sushiSpeed;
        numb = orders.orderNumber;
        adjust = conveyor.endlessAdjustment;

        pufferPos = this.transform.position;
        pufferPos.x = Mathf.Clamp(transform.position.x, 0f, 0f);

        pufferPos.z -= ((conveyor.sushiSpeed * orders.orderNumber) - conveyor.endlessAdjustment) * Time.deltaTime;
        transform.position = pufferPos;
    }



    private void OnTriggerEnter(Collider other){
        if(other.GetComponent<Collider>().gameObject.tag == "Conveyor"){
            canJump = true;
           //rb.AddForce(objectUp * Time.deltaTime, ForceMode.Impulse);
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.GetComponent<Collider>().gameObject.tag == "Conveyor"){
            canJump = false;
        }
    }
    /*private void FixedUpdate(){
        if(canJump){
            transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
        }
        else{
            pufferPos = this.transform.position;
            pufferPos.x = Mathf.Clamp(transform.position.x, 0f, 0f);

            pufferPos.z -= ((1f * orders.orderNumber) - conveyor.endlessAdjustment) * Time.deltaTime;
            //transform.position.x = pufferPos.x;
            //transform.position.z = pufferPos.z;
            transform.Translate(new Vector3(pufferPos.x, velocity, pufferPos.z) * Time.deltaTime);
        }
    }*/

    //1.65 -> 2.5 -> 1.65
    //.245
    //5*/
}
