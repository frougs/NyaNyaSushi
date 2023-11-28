using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int level = 1;
    private bool triggerOnce = true;
    [SerializeField] GameObject level1;
    [SerializeField] GameObject level2;
    [SerializeField] GameObject level3;
    [SerializeField] GameObject level4;
    [SerializeField] GameObject level5;
    [SerializeField] GameObject level6;
    [SerializeField] GameObject secretLevel;
    void Awake()
    {
        if(PlayerPrefs.GetInt("Level") <= 0){
            PlayerPrefs.SetInt("Level", 1); 
            level = 1;
        }
        level = PlayerPrefs.GetInt("Level");
        
        level2.SetActive(false);
        level3.SetActive(false);
        level4.SetActive(false);
        level5.SetActive(false);
        level6.SetActive(false);
        secretLevel.SetActive(false);
    }
    
    public void Update(){
        
        if(level >= 1){
            //Enable level 1 button
            level1.SetActive(true);
        }
        if(level >= 2){
            //Enable level 2 button
            level2.SetActive(true);
        }
        if(level >= 3){
            //Enable level 3 button
            level3.SetActive(true);
        }
        if(level >= 4){
            level4.SetActive(true);
        }
        if(level >= 5){
            level5.SetActive(true);
        }
        if(level >= 6){
            level6.SetActive(true);
        }
        if(level >= 7){
            secretLevel.SetActive(true);
        }
    }

}
