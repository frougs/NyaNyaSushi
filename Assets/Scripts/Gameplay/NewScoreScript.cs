using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;
    private bool moving;
    [HideInInspector] public string fishTag;
    [SerializeField] NyakayamaAnimation animations;
    [SerializeField] OrderScript orders;
    [SerializeField] ParticleSystem sweatSystem;
    public List<string> sushiTags = new List<string>();

    [SerializeField] LivesScript lives;
    private void Start(){
        sushiTags.Add("Tuna");
        sushiTags.Add("Salmon");
        score = 0;
    }
    private void OnTriggerEnter(Collider other){
        if(sushiTags.Contains(other.gameObject.tag.ToString())){
            Debug.Log("List contains the tag");
        }
        if(other.gameObject.CompareTag(fishTag) && moving && orders.fishNumber != 0){
            score +=10;
            orders.fishNumber -= 1;
            animations.emotion = "excited";
            Destroy(other.gameObject);
        }
        else if (sushiTags.Contains(other.gameObject.tag.ToString()) && moving && other.gameObject.tag.ToString() != fishTag){
            //score -= 5;
            animations.emotion = "sad";
            sweatSystem.Play();
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Rice") && moving && orders.riceNumber != 0){
            score +=10;
            orders.riceNumber -= 1;
            animations.emotion = "excited";
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("Rice") && moving && orders.riceNumber <= 0){
           // score -= 5;
           animations.emotion = "sad";
           sweatSystem.Play();
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Avacado") && moving && orders.addonNumber != 0){
            score +=10;
            orders.addonNumber -=1;
            animations.emotion = "excited";
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("Avacado") && moving && orders.addonNumber <= 0){
            //score -= 5;
            animations.emotion = "sad";
            sweatSystem.Play();
            Destroy(other.gameObject);
        }
    }
    private void Update(){
        //Debug.Log(fishTag);
        moving = GetComponent<KnifeScript>().moving;


        scoreText.text = "Score: "+ score.ToString();
    }

}