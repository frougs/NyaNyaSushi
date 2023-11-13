using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BackToMenu : MonoBehaviour
{
    public void OpenLevel(int levelId)
    {
        string levelName = "Main Menu " + levelId;
        SceneManager.LoadScene(levelName);
    }

    public void OpenCredits(){
        SceneManager.LoadScene("Credits");
    }
}

