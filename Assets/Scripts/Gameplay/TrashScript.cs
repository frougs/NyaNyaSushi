using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    [SerializeField] LivesScript lives;
    [SerializeField] OrderScript order;
    [SerializeField] NyakayamaAnimation animations;
    [SerializeField] GameObject knife;
    [HideInInspector] public string fishTag;
    private List<string> sushiTags = new List<string>();
  

    void Update(){

    }

    void Start(){
        foreach(string a in knife.GetComponent<NewScoreScript>().sushiTags){
            sushiTags.Add(a);
        }
    }

    private void OnTriggerEnter(Collider other){
        var colliderTag = other.gameObject.tag;
        //Debug.Log(colliderTag);
        if(sushiTags.Contains(colliderTag) && colliderTag != fishTag){
            Destroy(other.gameObject);
        }
        else if(other.GetComponent<Collider>().gameObject.tag == fishTag && order.fishNumber != 0){
            if(order.graceCountdown <= 0){
                lives.lives -= 1;
                animations.emotion = "dizzy";
                Destroy(other.gameObject);
            }
            else{
            Destroy(other.gameObject);
            }
        }

        if(other.GetComponent<Collider>().gameObject.tag == "Rice" && order.riceNumber == 0){
            Destroy(other.gameObject);
        }
        else if(other.GetComponent<Collider>().gameObject.tag == "Rice" && order.riceNumber != 0){
            if(order.graceCountdown <= 0){
                lives.lives -= 1;
                animations.emotion = "dizzy";
                Destroy(other.gameObject);
            }
            else{
            Destroy(other.gameObject);
            }
        }

        if(other.GetComponent<Collider>().gameObject.tag == "Avacado" && order.addonNumber == 0){
            Destroy(other.gameObject);
        }
        else if(other.GetComponent<Collider>().gameObject.tag == "Avacado" && order.addonNumber != 0){
            if(order.graceCountdown <= 0){
                lives.lives -= 1;
                animations.emotion = "dizzy";
                Destroy(other.gameObject);
            }
            else{
            Destroy(other.gameObject);
            }

        }
    }

}
