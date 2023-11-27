using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class devControlsScript : MonoBehaviour
{
    public LevelManager levels;
    public void UnlockAllLevels(){
        PlayerPrefs.SetInt("Level", 6);
        levels.level = 6;
    }

    public void ResetLevels(){
        PlayerPrefs.SetInt("Level", 1);
        levels.level = 1;
    }
}
