using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    //[SerializeField] LivesScript lives;
    public bool triggerPowerup;
    private string powerupType;
    private ConveyorScript[] conveyorObjects;
    private PufferScript[] pufferObjects;
    private GameObject spawnerObj;
    private GameObject conveyorObj;
    [SerializeField] [Range(1, 5)] float freezeTime;

    public void Awake(){
        spawnerObj = GameObject.FindGameObjectWithTag("Spawner");
        conveyorObj = GameObject.FindGameObjectWithTag("Conveyor");
    }
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
            pufferObjects = FindObjectsOfType<PufferScript>();
            foreach (PufferScript obj in pufferObjects){
                obj.GetComponent<PufferScript>().pufferSpeed = 0f;
            }
            foreach (ConveyorScript obj in conveyorObjects){
                obj.GetComponent<ConveyorScript>().sushiSpeed = 0f;
                conveyorObj.SetActive(false);
                StartCoroutine(SpeedDelay());
                spawnerObj.SetActive(false);
            }
        }
    }

    public IEnumerator SpeedDelay(){
        yield return new WaitForSeconds(freezeTime);
        conveyorObjects = FindObjectsOfType<ConveyorScript>();
         pufferObjects = FindObjectsOfType<PufferScript>();
        foreach (ConveyorScript obj in conveyorObjects){
            obj.GetComponent<ConveyorScript>().sushiSpeed = 0.5f;
            conveyorObj.SetActive(true);
            spawnerObj.SetActive(true);
        }
        foreach (PufferScript obj in pufferObjects){
                obj.GetComponent<PufferScript>().pufferSpeed = 0.3f;
            }
        
    }
}
