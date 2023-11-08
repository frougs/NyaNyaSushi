using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [HideInInspector] public int level = 1;
    [SerializeField] GameObject level1;
    [SerializeField] GameObject level2;
    [SerializeField] GameObject level3;
    void Start()
    {
        if(level != 1){
        PlayerPrefs.SetInt("Level", 1);  
        }
        else{
            level = PlayerPrefs.GetInt("Level");
        }
    }
    
    public void Update(){
        if(level == 1){
            //Enable level 1 button
        }
        if(level == 2){
            //Enable level 2 button
        }
        if(level == 3){
            //Enable level 3 button
        }
    }

}
