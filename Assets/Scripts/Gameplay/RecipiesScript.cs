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
    [SerializeField] [Range(1, 3)] int maxATuna;
    [SerializeField] [Range(1, 2)] int maxARice;
    [SerializeField] [Range(1, 2)] int maxAvacado;


    public void RecipieSelect(int recipieNumber){
        if(recipieNumber == 1){
            TunaSushi();
        }
        if(recipieNumber == 2){
            SalmonSushi();
        }
        /*else if(recipieNumber == 2){
            TunaSushiWithAvacado();
        }*/
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

    /*void TunaSushiWithAvacado(){
        orders.fishNumber = Random.Range(1, maxATuna);
        orders.riceNumber = Random.Range(1, maxARice);
        orders.addonNumber = Random.Range(1, maxAvacado);
        orders.addonTextString = "Avacado";
        orders.fishTextString = "Tuna";
        recipieName = "Tuna Sushi with Avacado";
    }*/
}
