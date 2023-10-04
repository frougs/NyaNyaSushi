using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;
    private bool moving;
    [SerializeField] OrderScript orders;
    private void Start(){
        score = 0;
    }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Sushi") && moving){
            score +=1;
            orders.sushiNumber -= 1;
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Rice") && moving){
            score +=1;
            orders.riceNumber -= 1;
            Destroy(other.gameObject);
        }
    }
    private void Update(){

        moving = GetComponent<KnifeScript>().moving;


        scoreText.text = "Score: "+ score.ToString();
    }
}