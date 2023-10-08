using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorScript : MonoBehaviour
{
    private bool moving;
    private Vector3 sushiPos;
    [Header("Sushi Conveyor Speed")]
    [SerializeField] float sushiSpeed;
    Rigidbody rb;
    private Vector3 movement;
    OrderScript orders;
    private int orderNum;

    void Start(){
        rb = this.GetComponent<Rigidbody>();
        orders = FindObjectOfType<OrderScript>();
    }
    void Update()
    {
        orderNum = orders.orderNumber;

        sushiPos = transform.position;
        sushiPos.x = Mathf.Clamp(transform.position.x, 0f, 0f);
    }

    void FixedUpdate(){
        if(moving){
            sushiPos.z -= (sushiSpeed * orderNum) * Time.deltaTime;
            transform.position = sushiPos;
        }
        
    }

    private void OnTriggerEnter(Collider other){
        if(other.GetComponent<Collider>().gameObject.tag == "Conveyor"){
            moving = true;
        }

    }
    private void OnTriggerExit(Collider other){
        if(other.GetComponent<Collider>().gameObject.tag == "Conveyor"){
            moving = false;
            
        }
    }
}
