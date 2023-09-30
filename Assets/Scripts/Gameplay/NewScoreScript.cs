using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;
    private void Start(){
        score = 0;
    }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Sushi")){
            score +=1;
            Destroy(other.gameObject);
        }
    }
    private void Update(){
        scoreText.text = "Score: "+ score.ToString();
    }
}