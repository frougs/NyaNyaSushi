using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderScript : MonoBehaviour
{
    public int fishNumber;
    public int riceNumber;
    public int addonNumber;
    public int addon2Number;
    public int orderNumber;
    [SerializeField] bool isCurrentOrder;
    [Header("Text Objects")]
    [SerializeField] TextMeshPro fishText;
    [SerializeField] TextMeshPro riceText;
    [SerializeField] TextMeshPro addonText;
    [SerializeField] TextMeshPro addon2Text;
    [SerializeField] TextMeshPro recipieName;
    [SerializeField] GameObject menuAddon1;
    [SerializeField] GameObject menuAddon2;
    /*[HideInInspector] */public string recipieText;
    [SerializeField] TextMeshPro orderNumberText;

    //[SerializeField] RecipiesScript recipies;

    [SerializeField] private float gracePeriod;
    [HideInInspector] public float graceCountdown;

    [SerializeField] [Range(1, 5)] int numberOfRecipies;
    [SerializeField] int recipieOverride;
    private int selectedRecipie;
    [SerializeField] GameObject ordersObject;
    [SerializeField] float orderCD = 1.5f;
    private float internalOrderCD;

    [Header("Just for testing")]
    [SerializeField] float orderNums;
    public bool ordersComplete;
    public bool endlessMode;
    //[SerializeField] float endlessSpeedAdjustment;
    //[HideInInspector] public string fishTextString;
    [HideInInspector] public string addonTextString;
    [SerializeField] GameObject finishedTuna;
    [SerializeField] GameObject finishedSalmon;
    [SerializeField] GameObject finishedAvacado;
    [SerializeField] GameObject menuTuna;
    [SerializeField] GameObject menuSalmon;
    [SerializeField] GameObject menuAvacado;
    [SerializeField] GameObject menuClam;
    [SerializeField] GameObject menuEel;
    [SerializeField] GameObject menuUrchin;
    [SerializeField] ParticleSystem menuBoard1;
    [SerializeField] ParticleSystem menuBoard2;
    [SerializeField] ParticleSystem newOrder1;
    [SerializeField] ParticleSystem newOrder2;


    private GameObject[] tunaInGame;
    private GameObject[] salmonInGame;
    private GameObject[] riceInGame;
    private GameObject[] avacadoInGame;
    private GameObject[] puffInGame;
    private ConveyorScript[] convObjs;

    [SerializeField] AudioSource dingSource;
    [SerializeField] OrderCompleteAnimationScript orderAnim;
    [HideInInspector] public bool orderParticles;
    [SerializeField] NextOrderScript nextOrder;

    [SerializeField] TrashScript trash;
    [SerializeField] NewScoreScript score;
    //[SerializeField] GameObject menuCucumber;

    /*[HideInInspector]*/ public int currentAddonAmount;
    private bool canNewOrder;
    private void Start(){
        //orderNumber = 1;
        graceCountdown = gracePeriod;
        //orderNumber = 1;
        //GenerateOrder();
        if(endlessMode){
            orderNums = Mathf.Infinity;
        }
        StartCoroutine(OrderDelay());
    }

    private void Update(){

        if(orderParticles){
            menuBoard1.Play();
            menuBoard2.Play();
            newOrder1.Play();
            newOrder2.Play();
            orderParticles = false;
        }
        graceCountdown -= Time.deltaTime;

        /*if(endlessMode){
            ConveyorScript[] sushiObjects = FindObjectsOfType<ConveyorScript>();
            foreach(ConveyorScript g in sushiObjects){
                g.endlessAdjustment = endlessSpeedAdjustment;
            }
        }*/


        if(recipieText.Contains("Tuna")){
            finishedTuna.SetActive(true);
            menuTuna.SetActive(true);
            trash.fishTag = "Tuna";
            score.fishTag = "Tuna";
        }
        else{
            finishedTuna.SetActive(false);
            menuTuna.SetActive(false);
        }
        if(recipieText.Contains("Salmon")){
            finishedSalmon.SetActive(true);
            menuSalmon.SetActive(true);
            trash.fishTag = "Salmon";
            score.fishTag = "Salmon";
        }
        else{
            finishedSalmon.SetActive(false);
            menuSalmon.SetActive(false);
        }
        /*if(recipieText.Contains("Avacado")){
            finishedAvacado.SetActive(true);
            menuAvacado.SetActive(true);
        }
        else{
            finishedAvacado.SetActive(false);
            menuAvacado.SetActive(false);
        }*/

        if(currentAddonAmount == 1 || currentAddonAmount == 2){
            menuAvacado.SetActive(true);
        }
        else{
            menuAvacado.SetActive(false);
        }
        //if(currentAddonAmount == 2){
            //menuCucumber.SetActive(true);
        //}

        if(recipieText.Contains("Kobashira")){
            trash.fishTag = "Clam";
            score.fishTag = "Clam";
            menuClam.SetActive(true);
        }
        else{
            menuClam.SetActive(false);
        }
        if(recipieText.Contains("Sea Urchin")){
            trash.fishTag = "UrchinNoSpikes";
            score.fishTag = "UrchinNoSpikes";
            menuUrchin.SetActive(true);
        }
        else{
            menuUrchin.SetActive(false);
        }
        if(recipieText.Contains("UnakyuMaki")){
            trash.fishTag = "Eel";
            score.fishTag = "Eel";
            menuEel.SetActive(true);
        }
        else{
            menuEel.SetActive(false);
        }

            


        orderNumberText.text = "Order #" +orderNumber.ToString();
        recipieName.text = "Recipie: " +recipieText;
        fishText.text = fishNumber.ToString() +"X";
        riceText.text = riceNumber.ToString() +"X";
        addonText.text = addonNumber.ToString() + "X";
        addon2Text.text = addon2Number.ToString() + "X";
        if(currentAddonAmount >= 1){
            //addonText.text = addonNumber.ToString() + "X";
            addonText.gameObject.SetActive(true);
        }
        if(currentAddonAmount == 2){
            //addon2Text.text = addon2Number.ToString() + "X";
            addon2Text.gameObject.SetActive(true);
        }
        else if(currentAddonAmount == 0){
            addonText.gameObject.SetActive(false);
            addon2Text.gameObject.SetActive(false);
        }

        if(riceNumber <= 0){
            riceNumber = 0;
        }
        if(fishNumber <=0){
            fishNumber = 0;
        }
        if(addonNumber <=0){
            addonNumber = 0;
        }

        if(fishNumber == 0 && riceNumber == 0 && addonNumber == 0 && canNewOrder && addon2Number == 0){
            dingSource.Play();
            orderNumber += 1;
            fishNumber = nextOrder.nextfishNumber;
            riceNumber = nextOrder.nextriceNumber;
            addonNumber = nextOrder.nextaddonNumber;
            addon2Number  = nextOrder.nextaddon2Number;
            if(currentAddonAmount >= 1){
                addonText.gameObject.SetActive(true);
                //addon2Text.gameObject.SetActive(false);
                //menuAddon2.SetActive(false);
                menuAddon1.SetActive(true);
                //addonNumber = nextOrder.nextaddonNumber;
            }
            else if(currentAddonAmount == 2){
                addon2Text.gameObject.SetActive(true);
                menuAddon2.SetActive(true);
                //addon2Number  = nextOrder.nextaddon2Number;
            }
            else if(currentAddonAmount == 0){
                addonText.gameObject.SetActive(false);
                addon2Text.gameObject.SetActive(false);
                menuAddon2.SetActive(false);
                menuAddon1.SetActive(false);
                //addonNumber = 0;
                //addon2Number = 0;
            }
            recipieText = nextOrder.nextRecipieName;
            currentAddonAmount = nextOrder.nextAddonAmount;
            nextOrder.GenerateOrder();
            graceCountdown = gracePeriod;
            menuBoard1.Play();
            menuBoard2.Play();
            newOrder1.Play();
            newOrder2.Play();
            //ClearConveyor();
            orderAnim.triggerAnim = true;
        }

        if(orderNumber == orderNums){
            ordersComplete = true;
        }
    }

    public void ClearConveyor(){
        convObjs = FindObjectsOfType<ConveyorScript>();
        tunaInGame = GameObject.FindGameObjectsWithTag("Tuna");
        salmonInGame = GameObject.FindGameObjectsWithTag("Salmon");
        foreach(GameObject tuna in tunaInGame){
            Destroy(tuna);
        }
        foreach(GameObject salmon in salmonInGame){
            Destroy(salmon);
        }

        riceInGame = GameObject.FindGameObjectsWithTag("Rice");
            foreach(GameObject riceObjects in riceInGame){
                Destroy(riceObjects);
            }
        avacadoInGame = GameObject.FindGameObjectsWithTag("Avacado");
        foreach(GameObject avacadoObjects in avacadoInGame){
            Destroy(avacadoObjects);
        }
        puffInGame = GameObject.FindGameObjectsWithTag("Puffer");
        foreach(GameObject pufferObjects in puffInGame){
            Destroy(pufferObjects);
        }
        foreach(ConveyorScript obj in convObjs){
            Destroy(obj);
        }
    }
    private IEnumerator OrderDelay(){
        yield return new WaitForSeconds(0.1f);
        canNewOrder = true;
    }

    private void FixedUpdate(){
        if(currentAddonAmount == 0){
            addonNumber = 0;
            addon2Number = 0;
        }
    }
}







