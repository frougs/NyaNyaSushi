using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveConveyor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        if(other.GetComponent<ConveyorScript>() != null){
            Destroy(other.GetComponent<ConveyorScript>());
        }
        if(other.GetComponent<PufferScript>() != null){
            Destroy(other.GetComponent<PufferScript>());
        }
    }
}
