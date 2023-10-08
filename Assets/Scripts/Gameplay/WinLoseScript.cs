using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseScript : MonoBehaviour
{

    [SerializeField] NewScoreScript scoreScript;
    [SerializeField] OrderScript orderScript;
    [SerializeField] LivesScript livesNum;

    [SerializeField] int winScore;
    private int score;
    private bool ordersComplete;
    private int lives;

    
    void Update()
    {
        lives = livesNum.lives;
        score = scoreScript.score;
        ordersComplete = orderScript.ordersComplete;

        if(score < 0 || lives <= 0){
            Lose();
        }

        if(ordersComplete || score == winScore){
            Win();
        }
    }

    void Lose(){
        Debug.Log("U lost");
    }

    void Win(){
        Debug.Log("U win");
    }
}
