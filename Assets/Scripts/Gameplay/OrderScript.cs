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
    [HideInInspector] public string recipieText;
    [SerializeField] TextMeshPro orderNumberText;

    [SerializeField] RecipiesScript recipies;

    [SerializeField] private float gracePeriod;
    [HideInInspector] public float graceCountdown;

    [SerializeField] [Range(1, 5)] int numberOfRecipies;
    [SerializeField] int recipieOverride;
    private int selectedRecipie;

    [Header("Just for testing")]
    [SerializeField] float orderNums;
    public bool ordersComplete;
    public bool endlessMode;
    [SerializeField] float endlessSpeedAdjustment;
    [HideInInspector] public string fishTextString;
    [HideInInspector] public string addonTextString;
    [SerializeField] GameObject finishedTuna;
    [SerializeField] GameObject finishedSalmon;
    [SerializeField] GameObject finishedAvacado;
    [SerializeField] ParticleSystem menuBoard1;
    [SerializeField] ParticleSystem menuBoard2;
    [SerializeField] ParticleSystem newOrder1;
    [SerializeField] ParticleSystem newOrder2;


    private GameObject[] fishInGame;
    private GameObject[] riceInGame;

    private void Start(){
        graceCountdown = gracePeriod;
        orderNumber = 1;
        GenerateOrder();
        if(endlessMode){
            orderNums = Mathf.Infinity;
        }
    }

    private void Update(){
        if(endlessMode){
            ConveyorScript[] sushiObjects = FindObjectsOfType<ConveyorScript>();
            foreach(ConveyorScript g in sushiObjects){
                g.endlessAdjustment = endlessSpeedAdjustment;
            }
        }


        if(recipieText.Contains("Tuna")){
            finishedTuna.SetActive(true);
        }
        else{
            finishedTuna.SetActive(false);
        }
        if(recipieText.Contains("Salmon")){
            finishedSalmon.SetActive(true);
        }
        else{
            finishedSalmon.SetActive(false);
        }
        if(recipieText.Contains("Avacado")){
            finishedAvacado.SetActive(true);
        }
        else{
            finishedAvacado.SetActive(false);
        }




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
        Random.InitState(System.DateTime.Now.Millisecond);
        Random.State randomizer = Random.state;
        selectedRecipie = Random.Range(1, numberOfRecipies+1);
        if(recipieOverride != 0){
            selectedRecipie = recipieOverride;
        }
        Debug.Log(selectedRecipie);
        recipies.RecipieSelect(selectedRecipie);
        menuBoard1.Play();
        menuBoard2.Play();
        newOrder1.Play();
        newOrder2.Play();



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
