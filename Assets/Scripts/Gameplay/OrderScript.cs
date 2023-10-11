using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderScript : MonoBehaviour
{
    public int fishNumber;
    public int riceNumber;
    public int orderNumber;
    [Header("Text Objects")]
    [SerializeField] TextMeshPro fishText;
    [SerializeField] TextMeshPro riceText;
    [SerializeField] TextMeshPro orderNumberText;

    [SerializeField] RecipiesScript recipies;

    [SerializeField] private float gracePeriod;
    [HideInInspector] public float graceCountdown;

    [SerializeField] [Range(1, 5)] int numberOfRecipies;
    private int selectedRecipie;

    [Header("Just for testing")]
    [SerializeField] int orderNums;
    public bool ordersComplete;

    private string fishText;

    private GameObject[] fishInGame;
    private GameObject[] riceInGame;

    private void Start(){
        graceCountdown = gracePeriod;
        orderNumber = 1;
        GenerateOrder();
    }

    private void Update(){
        //Debug.Log(graceCountdown);
        graceCountdown -= Time.deltaTime;
        if(graceCountdown <= 0){
            graceCountdown = 0;
        }
        orderNumberText.text = "Order #" +orderNumber.ToString();

        sushiText.text = sushiNumber.ToString() +"X " + fishText;
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
            graceCountdown = gracePeriod;
            //ClearConveyor();
        }

        if(orderNumber == orderNums){
            ordersComplete = true;
        }
    }

    void GenerateOrder(){
        //sushiNumber = Random.Range(1, 5);
        //riceNumber = Random.Range(1, 2);
        selectedRecipie = Random.Range(1, numberOfRecipies);

        //recipies.


    }

    /*void ClearConveyor(){
        sushiInGame = GameObject.FindGameObjectsWithTag("Sushi");
            foreach(GameObject sushiObjects in sushiInGame){
                Destroy(sushiObjects);
        }
        riceInGame = GameObject.FindGameObjectsWithTag("Rice");
            foreach(GameObject riceObjects in riceInGame){
                Destroy(riceObjects);
            }
    }*/

}
