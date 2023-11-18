using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipiesScript : MonoBehaviour
{

    [SerializeField] NextOrderScript orders;
    [HideInInspector] public string recipieName;

    [Header("Tuna Sushi Recipie")]
    [SerializeField] [Range(1, 5)] int maxTuna;
    [SerializeField] [Range(1, 3)] int maxTunaRice;
    [Header("Salmon Sushi Recipie")]
    [SerializeField] [Range(1,3)] int maxSalmon;
    [SerializeField] [Range(1,2)] int maxSalmonRice;
    [Header("Tuna Sushi With Avacado")]
    [SerializeField] [Range(1, 3)] int maxAFish;
    [SerializeField] [Range(1, 2)] int maxARice;
    [SerializeField] [Range(1, 2)] int maxAvacado;
    [Header("KobaShira")]
    [SerializeField] [Range(1, 2)] int maxClam;
    [SerializeField] [Range(1, 2)] int maxKRice;
    [Header("Unakyu Maki")]
    [SerializeField] [Range(1, 3)] int maxEel;
    [SerializeField] [Range(1, 2)] int maxUCucumber;
    [SerializeField] [Range(1, 3)] int maxURice;
    [SerializeField] [Range(1, 2)] int maxUAvo;
    [Header("Sea Urchin")]
    [SerializeField] [Range(1, 3)] int maxUrchin;
    [SerializeField] [Range(1, 3)] int maxUrRice;
    private string rFishName;


    public void RecipieSelect(int recipieNumber){
        Debug.Log(recipieNumber);
        if(recipieNumber == 1){
            TunaSushi();
        }
        else if(recipieNumber == 2){
            SalmonSushi();
        }
        else if(recipieNumber == 3){
            SushiWithAvacado();
        }
        else if(recipieNumber == 4){
            Kobashira();
        }
        else if(recipieNumber == 6){
            UnakyuMaki();
        }
        else if(recipieNumber == 5){
            SeaUrchin();
        }

        orders.nextRecipieName = recipieName;
    }

    void TunaSushi(){
        orders.nextfishNumber = Random.Range(1, maxTuna);
        orders.nextriceNumber = Random.Range(1, maxTunaRice);
        orders.nextAddonAmount = 0;

        recipieName = "Tuna Sushi";

    }

    void SalmonSushi(){
        orders.nextfishNumber = Random.Range(1, maxSalmon);
        orders.nextriceNumber = Random.Range(1, maxSalmonRice);
        orders.nextAddonAmount = 0;

        recipieName = "Salmon Sushi";

    }

    void SushiWithAvacado(){
        orders.nextfishNumber = Random.Range(1, maxAFish);
        orders.nextriceNumber = Random.Range(1, maxARice);
        orders.nextaddonNumber = Random.Range(1, maxAvacado);
        orders.nextAddonAmount = 1;
        var aFish = Random.Range(1, 2);

            if(aFish == 1){

                rFishName = "Tuna";
            }
            else if(aFish == 2){

                rFishName = "Salmon";
            }
        //orders.nextAddonAmount = 1;
        recipieName = rFishName.ToString() + " sushi with Avacado";    
    }
    void Kobashira(){
        orders.nextfishNumber = Random.Range(1, maxClam);
        orders.nextriceNumber = Random.Range(1, maxKRice);
        recipieName = "Kobashira";
        orders.nextAddonAmount = 0;
    }
    void UnakyuMaki(){
        orders.nextfishNumber = Random.Range(1, maxEel);
        orders.nextriceNumber = Random.Range(1, maxUrRice);
        orders.nextaddon2Number = Random.Range(1, maxUCucumber);
        orders.nextaddonNumber = Random.Range(1, maxUAvo);
        orders.nextAddonAmount = 2;
        recipieName = "UnakyuMaki";
    }
    void SeaUrchin(){
        orders.nextfishNumber = Random.Range(1, maxUrchin);
        orders.nextriceNumber = Random.Range(1, maxUrRice);
        orders.nextAddonAmount = 0;
        recipieName = "Sea Urchin";
    }

}

