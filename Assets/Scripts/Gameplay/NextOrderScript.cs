using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NextOrderScript : MonoBehaviour
{
    public int nextfishNumber;
    public int nextriceNumber;
    public int nextaddonNumber;
    public int nextorderNumber;
    public string nextFishTag;
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
    [SerializeField] GameObject ordersObject;


    [Header("Just for testing")]

    [HideInInspector] public string addonTextString;

    [SerializeField] GameObject menuTuna;
    [SerializeField] GameObject menuSalmon;
    [SerializeField] ParticleSystem menuBoard1;
    [SerializeField] ParticleSystem menuBoard2;



    private GameObject[] tunaInGame;
    private GameObject[] salmonInGame;
    private GameObject[] riceInGame;
    private GameObject[] avacadoInGame;
    private GameObject[] puffInGame;



    [SerializeField] OrderScript currentOrder;

    public string nextRecipieName;

    private void Start(){

        GenerateOrder();

        
    }

    private void Update(){

        if(nextRecipieName.Contains("Tuna")){

            menuTuna.SetActive(true);
        }
        else{

            menuTuna.SetActive(false);
        }
        if(nextRecipieName.Contains("Salmon")){

            menuSalmon.SetActive(true);
        }
        else{

            menuSalmon.SetActive(false);
        }
    }

    public void GenerateOrder(){

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
        //newOrder1.Play();
        //newOrder2.Play();
        nextRecipieName = recipies.recipieName;
        fishText.text = nextfishNumber.ToString() + "X";
        riceText.text = nextriceNumber.ToString() + "X";
        addonText.text = nextaddonNumber.ToString() + "X";
        recipieName.text = "Recipie: " +nextRecipieName;
        


        


    }
}







