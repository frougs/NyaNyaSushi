using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesScript : MonoBehaviour
{
    [SerializeField] OrderScript orders;

    public int lives;
    [SerializeField] bool infiniteLives;

    [SerializeField] WinLoseScript winLose;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] GameObject lives1;
    [SerializeField] GameObject lives2;
    [SerializeField] GameObject lives3;

    void Start(){

    }


    void Update(){
        if(lives == 1 && infiniteLives){
                lives += 10;
            }
        
        if(lives <= 0){
            lives = 0;

        }
        //livesText.text = "Lives: " + lives.ToString();

        if(lives == 3){
            lives1.SetActive(true);
            lives2.SetActive(true);
            lives3.SetActive(true);
        }
        if(lives == 2){
            lives3.SetActive(false);
        }
        if(lives == 1){
            lives2.SetActive(false);
        }
        if(lives == 0){
            lives1.SetActive(false);
        }
    }
}
