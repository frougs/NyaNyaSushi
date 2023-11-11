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
    void Start()
    {
        if(PlayerPrefs.GetInt("Level") <= 0){
            PlayerPrefs.SetInt("Level", 1); 
            level = 1;
        }
        level = PlayerPrefs.GetInt("Level");

    }
    
    public void Update(){

        
        if(level == 1){
            //Enable level 1 button
            level1.SetActive(true);
            level2.SetActive(false);
            level3.SetActive(false);
        }
        if(level == 2){
            //Enable level 2 button
            level2.SetActive(true);
            level3.SetActive(false);
        }
        if(level == 3){
            //Enable level 3 button
            level3.SetActive(true);
        }
    }

}
