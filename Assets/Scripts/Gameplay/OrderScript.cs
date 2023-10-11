using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderScript : MonoBehaviour
{
    public int fishNumber;
    public int riceNumber;
    public int addonNumber;
    public int orderNumber;
    [Header("Text Objects")]
    [SerializeField] TextMeshPro fishText;
    [SerializeField] TextMeshPro riceText;
    [SerializeField] TextMeshPro addonText;
    [SerializeField] TextMeshPro recipieName;
    [SerializeField] TextMeshPro orderNumberText;

    [SerializeField] RecipiesScript recipies;

    [SerializeField] private float gracePeriod;
    [HideInInspector] public float graceCountdown;

    [SerializeField] [Range(1, 5)] int numberOfRecipies;
    private int selectedRecipie;

    [Header("Just for testing")]
    [SerializeField] int orderNums;
    public bool ordersComplete;

    [HideInInspector] public string fishTextString;
    [HideInInspector] public string addonTextString;

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
        recipieName.text = "Recipie: " +recipies.recipieName;
        fishText.text = fishNumber.ToString() +"X " + fishTextString;
        riceText.text = riceNumber.ToString() +"X Rice";
        addonText.text = addonNumber.ToString() + "X " + addonTextString;

        if(riceNumber <= 0){
            riceNumber = 0;
        }
        if(fishNumber <=0){
            fishNumber = 0;
        }
        if(addonNumber <=0){
            addonNumber = 0;
        }

        if(fishNumber == 0 && riceNumber == 0 && addonNumber == 0){
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
        Random.seed = System.DateTime.Now.Millisecond;
        selectedRecipie = Random.Range(1, numberOfRecipies);
        Debug.Log(selectedRecipie);
        recipies.RecipieSelect(selectedRecipie);


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
