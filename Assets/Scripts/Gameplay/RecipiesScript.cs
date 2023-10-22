using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipiesScript : MonoBehaviour
{

    [SerializeField] OrderScript orders;
    [SerializeField] TrashScript trash;
    [SerializeField] NewScoreScript score;
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
    private string rFishName;


    public void RecipieSelect(int recipieNumber){
        if(recipieNumber == 1){
            TunaSushi();
        }
        else if(recipieNumber == 2){
            SalmonSushi();
        }
        else if(recipieNumber == 3){
            SushiWithAvacado();
        }
        orders.recipieText = recipieName;
    }

    void TunaSushi(){
        orders.fishNumber = Random.Range(1, maxTuna);
        orders.riceNumber = Random.Range(1, maxTunaRice);
        orders.fishTextString = "Tuna";
        recipieName = "Tuna Sushi";
        trash.fishTag = "Tuna";
        score.fishTag = "Tuna";
    }

    void SalmonSushi(){
        orders.fishNumber = Random.Range(1, maxSalmon);
        orders.riceNumber = Random.Range(1, maxSalmonRice);
        orders.fishTextString = "Salmon";
        recipieName = "Salmon Sushi";
        trash.fishTag = "Salmon";
        score.fishTag = "Salmon";
    }

    void SushiWithAvacado(){
        orders.fishNumber = Random.Range(1, maxAFish);
        orders.riceNumber = Random.Range(1, maxARice);
        orders.addonNumber = Random.Range(1, maxAvacado);
        var aFish = Random.Range(1, 2);

            if(aFish == 1){
                orders.fishTextString = "Tuna";
                trash.fishTag = "Tuna";
                score.fishTag = "Tuna";
                rFishName = "Tuna";
            }
            else if(aFish == 2){
                orders.fishTextString = "Salmon";
                trash.fishTag = "Salmon";
                score.fishTag = "Salmon";
                rFishName = "Salmon";
            }
        orders.addonTextString = "Avacado";
        recipieName = rFishName.ToString() + " sushi with Avacado";
        
        }

    }

