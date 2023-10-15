using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScript : MonoBehaviour
{

    [SerializeField] NewScoreScript scoreScript;
    [SerializeField] OrderScript orderScript;
    [SerializeField] LivesScript livesNum;
    [SerializeField] GameObject winObject;
    [SerializeField] GameObject loseObject;
    [SerializeField] GameObject dimObject;
    [SerializeField] NyakayamaAnimation animations;
    [SerializeField] int winScore;
    private int score;
    private bool ordersComplete;
    private int lives;

    void Start(){
        Time.timeScale = 1;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
        lives = livesNum.lives;
        score = scoreScript.score;
        ordersComplete = orderScript.ordersComplete;

        if(score < 0 || lives <= 0){
            Lose();
            animations.emotion = "sad";
        }

        if(ordersComplete || score == winScore){
            Win();
            animations.emotion = "sad";
        }
    }

    void Lose(){
        Time.timeScale = 0;
        loseObject.SetActive(true);
        dimObject.SetActive(true);
    }

    void Win(){
        Time.timeScale = 0;
        winObject.SetActive(true);
        dimObject.SetActive(true);
    }
}
