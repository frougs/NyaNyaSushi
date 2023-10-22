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

    void Start(){

    }


    void Update(){
        if(lives == 1 && infiniteLives){
                lives += 10;
            }
        
        if(lives <= 0){
            lives = 0;

        }
        livesText.text = "Lives: " + lives.ToString();
    }
}
