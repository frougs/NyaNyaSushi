using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    //[SerializeField] LivesScript lives;
    public bool triggerPowerup;
    private string powerupType;
    private ConveyorScript[] conveyorObjects;

    public void PowerUp(string type){
        /*if(type == "autoComplete"){
            //include auto complete power up functionality here
        }*/
        /*if(type == "timeSlow"){
            //include time slow power up functionality here
        }*/
        /*if(type == "extraPoints"){
            //include extra points functionality here
        }*/
        if(type == "freezeBelt"){
            //include freeze belt functionality here
            Debug.Log("Triggering freeze powerup");
            conveyorObjects = FindObjectsOfType<ConveyorScript>();
            foreach (ConveyorScript obj in conveyorObjects){
                obj.GetComponent<ConveyorScript>().sushiSpeed = 0f;
                StartCoroutine(SpeedDelay());
            }
        }
    }

    public IEnumerator SpeedDelay(){
        yield return new WaitForSeconds(1.5f);
        foreach (ConveyorScript obj in conveyorObjects){
            obj.GetComponent<ConveyorScript>().sushiSpeed = 0.5f;

        }
        
    }
}
