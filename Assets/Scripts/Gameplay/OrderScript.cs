using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderScript : MonoBehaviour
{
    public int sushiNumber;
    public int riceNumber;
    public int orderNumber;
    [Header("Text Objects")]
    [SerializeField] TextMeshPro sushiText;
    [SerializeField] TextMeshPro riceText;
    [SerializeField] TextMeshPro orderNumberText;

    [Header("Just for testing")]
    [SerializeField] int orderNums;
    public bool ordersComplete;

    private void Start(){
        orderNumber = 1;
        GenerateOrder();
    }

    private void Update(){

        orderNumberText.text = "Order #" +orderNumber.ToString();

        sushiText.text = sushiNumber.ToString() +"X Sushi";
        riceText.text = riceNumber.ToString() +"X Rice";

        if(riceNumber <= 0){
            riceNumber = 0;
        }
        if(sushiNumber <=0){
            sushiNumber = 0;
        }

        if(sushiNumber == 0 && riceNumber == 0){
            orderNumber += 1;
            GenerateOrder();
        }

        if(orderNumber == orderNums){
            ordersComplete = true;
        }
    }

    void GenerateOrder(){
        sushiNumber = Random.Range(1, 5);
        riceNumber = Random.Range(1, 2);

    }


}
