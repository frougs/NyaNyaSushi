using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorScript : MonoBehaviour
{
    [HideInInspector] public bool moving;
    private Vector3 sushiPos;
    [Header("Sushi Conveyor Speed")]
    [SerializeField] float sushiSpeed;
    [HideInInspector] public float endlessAdjustment;
    Rigidbody rb;
    private Vector3 movement;
    PufferScript puffer;
    OrderScript orders;
    private int orderNum;

    void Start(){
        rb = this.GetComponent<Rigidbody>();
        orders = FindObjectOfType<OrderScript>();
        puffer = this.GetComponent<PufferScript>();

    }
    void Update()
    {
        //if(puffer != null){
           // moving = true;
       // }
        orderNum = orders.orderNumber;

        sushiPos = transform.position;
        sushiPos.x = Mathf.Clamp(transform.position.x, 0f, 0f);
    }

    void FixedUpdate(){
        if(moving){
            sushiPos.z -= ((sushiSpeed * orderNum) - endlessAdjustment) * Time.deltaTime;
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
