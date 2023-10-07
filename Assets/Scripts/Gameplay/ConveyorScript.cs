using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorScript : MonoBehaviour
{
    private bool moving;
    private Vector3 sushiPos;
    [Header("Sushi Conveyor Speed")]
    [SerializeField] float sushiSpeed;

    void Update()
    {
        sushiPos = transform.position;
        sushiPos.x = Mathf.Clamp(transform.position.x, 0f, 0f);
        if(moving){
            sushiPos.z -= sushiSpeed;
        }
        transform.position = sushiPos;
    }

    private void OnTriggerEnter(Collider other){
        if(other.GetComponent<Collider>().gameObject.tag == "Conveyor"){
            moving = true;
        }

        if(other.GetComponent<Collider>().gameObject.tag == "Trash"){
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.GetComponent<Collider>().gameObject.tag == "Conveyor"){
            moving = false;
            
        }
    }
}
