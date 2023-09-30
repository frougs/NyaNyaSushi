using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{

    private int score;

    public TextMeshProUGUI scoreText;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        SetScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetScoreText()
    {
        scoreText.text = "Score: "+ score.ToString();
    }

     private void OnCollisionEnter(Collision collision)
   {
        if(collision.gameObject.tag == "Knife")
        {
           score = score + 1;
            
        }
   }
}
