using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderScript : MonoBehaviour
{
    public int sushiNumber;
    public int riceNumber;
    [Header("Text Objects")]
    [SerializeField] TextMeshPro sushiText;
    [SerializeField] TextMeshPro riceText;

    private void Start(){
        sushiNumber = Random.Range(1, 5);
        riceNumber = Random.Range(1, 2);

    }

    private void Update(){
        sushiText.text = sushiNumber.ToString() +"X Sushi";
        riceText.text = riceNumber.ToString() +"X Rice";

        if(riceNumber <= 0){
            riceNumber = 0;
        }
        if(sushiNumber <=0){
            sushiNumber = 0;
        }
    }


}
