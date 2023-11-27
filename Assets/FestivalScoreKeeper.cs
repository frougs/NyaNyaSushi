using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FestivalScoreKeeper : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI highScore;
    private void Update(){
        //Debug.Log(PlayerPrefs.GetInt("festHighScore"));
        highScore.text = "High Score: " +PlayerPrefs.GetInt("festHighScore");
    }
}
