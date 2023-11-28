using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelMenu : MonoBehaviour
{
    public void OpenLevel(int levelId)
    {
        string levelName = "Level " + levelId;
        SceneManager.LoadScene(levelName);
    }

    public void FestivalMode(){
        SceneManager.LoadScene("Endless");
    }

    public void SecretLevel(){
        SceneManager.LoadScene("DLC");
    }
}

