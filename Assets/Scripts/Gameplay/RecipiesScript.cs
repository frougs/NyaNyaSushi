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

        orders.nextRecipieName = recipieName;
    }

    void TunaSushi(){
        orders.nextfishNumber = Random.Range(1, maxTuna);
        orders.nextriceNumber = Random.Range(1, maxTunaRice);

        recipieName = "Tuna Sushi";

    }

    void SalmonSushi(){
        orders.nextfishNumber = Random.Range(1, maxSalmon);
        orders.nextriceNumber = Random.Range(1, maxSalmonRice);

        recipieName = "Salmon Sushi";

    }

    void SushiWithAvacado(){
        orders.nextfishNumber = Random.Range(1, maxAFish);
        orders.nextriceNumber = Random.Range(1, maxARice);
        orders.nextaddonNumber = Random.Range(1, maxAvacado);
        var aFish = Random.Range(1, 2);

            if(aFish == 1){

                rFishName = "Tuna";
            }
            else if(aFish == 2){

                rFishName = "Salmon";
            }
        recipieName = rFishName.ToString() + " sushi with Avacado";    
    }
    

}

