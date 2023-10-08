using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesScript : MonoBehaviour
{
    [SerializeField] OrderScript orders;

    public int lives;

    [SerializeField] WinLoseScript winLose;

    [SerializeField] TextMeshProUGUI livesText;

    void Update(){
        if(lives <= 0){
            lives = 0;
        }
        livesText.text = "Lives: " + lives.ToString();
    }
}
