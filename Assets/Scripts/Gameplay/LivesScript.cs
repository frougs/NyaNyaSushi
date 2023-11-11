using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    //[SerializeField] bool clearSavedLives;

    void Start(){
        var currentScene = SceneManager.GetActiveScene();
        if(currentScene.name != "Endless"){
            lives = PlayerPrefs.GetInt("Lives");

            if(lives <= 0){
                PlayerPrefs.SetInt("Lives", 3);
                lives = 3;
            }
        }
        else{
            lives = 3;
        }
    }



    void Update(){
       /* if(clearSavedLives){
            PlayerPrefs.DeleteKey("Lives");
            clearSavedLives = false;
        }*/
        if(lives == 1 && infiniteLives){
                lives += 10;
            }
        
        if(lives <= 0){
            lives = 0;

        }
        if(lives >= 3){
            lives = 3;
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
            lives3.SetActive(false);
        }
        if(lives == 0){
            lives1.SetActive(false);
            lives2.SetActive(false);
            lives3.SetActive(false);
        }
    }
}
