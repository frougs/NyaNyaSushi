using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    [SerializeField] LivesScript lives;
    [SerializeField] OrderScript order;

    void Update(){

    }

    private void OnTriggerEnter(Collider other){
        if(other.GetComponent<Collider>().gameObject.tag == "Sushi" && order.sushiNumber == 0){
            Destroy(other.gameObject);
        }
        else if(other.GetComponent<Collider>().gameObject.tag == "Sushi" && order.sushiNumber != 0){
            lives.lives -= 1;
            Destroy(other.gameObject);
        }

        if(other.GetComponent<Collider>().gameObject.tag == "Rice" && order.riceNumber == 0){
            Destroy(other.gameObject);
        }
        else if(other.GetComponent<Collider>().gameObject.tag == "Rice" && order.riceNumber != 0){
            lives.lives -=1;
            Destroy(other.gameObject);
        }
    }
}
