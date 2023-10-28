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
    [SerializeField] AudioSource knifeSource;
    [SerializeField] AudioSource pufferSource;
    [SerializeField] GameObject slices;
    private GameObject slicesObj;
    private bool triggerSound;

    [SerializeField] LivesScript lives;
    private void Start(){
        sushiTags.Add("Tuna");
        sushiTags.Add("Salmon");
        score = 0;
    }
    private void OnTriggerEnter(Collider other){
        if(moving && triggerSound || sushiTags.Contains(other.gameObject.tag.ToString())){
            knifeSource.Play();
            triggerSound = false;
        }
        
        if(sushiTags.Contains(other.gameObject.tag.ToString())){
            //Debug.Log("List contains the tag");
        }
        if(other.gameObject.CompareTag(fishTag) && moving && orders.fishNumber != 0){
            score +=10;
            orders.fishNumber -= 1;
            animations.emotion = "excited";
            Destroy(other.gameObject);
            triggerSound = true;
        }
        else if (sushiTags.Contains(other.gameObject.tag.ToString()) && moving && other.gameObject.tag.ToString() != fishTag){
            //score -= 5;
            animations.emotion = "sad";
            sweatSystem.Play();
            Destroy(other.gameObject);
            triggerSound = true;
        }

        if(other.gameObject.CompareTag("Rice") && moving && orders.riceNumber != 0){
            score +=10;
            orders.riceNumber -= 1;
            animations.emotion = "excited";
            Destroy(other.gameObject);
            triggerSound = true;
        }
        else if(other.gameObject.CompareTag("Rice") && moving && orders.riceNumber <= 0){
           // score -= 5;
           animations.emotion = "sad";
           sweatSystem.Play();
            Destroy(other.gameObject);
            triggerSound = true;
        }
        if(other.gameObject.CompareTag("Avacado") && moving && orders.addonNumber != 0){
            score +=10;
            orders.addonNumber -=1;
            var sliceSpawn = other.gameObject.transform.Find("SliceSpawnPoint");
            //Debug.Log(sliceSpawn);
            slicesObj = Instantiate(slices, transform);
            StartCoroutine(Vanish(slicesObj));
            animations.emotion = "excited";
            Destroy(other.gameObject);
            triggerSound = true;
        }
        else if(other.gameObject.CompareTag("Avacado") && moving && orders.addonNumber <= 0){
            //score -= 5;
            var sliceSpawn = other.gameObject.transform.Find("SliceSpawnPoint");
            //Debug.Log(sliceSpawn.transform.position);
            slicesObj = Instantiate(slices, transform);
            StartCoroutine(Vanish(slicesObj));
            animations.emotion = "sad";
            sweatSystem.Play();
            Destroy(other.gameObject);
            triggerSound = true;
        }
        else if(other.gameObject.CompareTag("Puffer") && moving){
            animations.emotion = "dizzy";
            sweatSystem.Play();
            Destroy(other.gameObject);
            pufferSource.Play();
            orders.GenerateOrder();
            lives.lives -= 1;
            orders.ClearConveyor();
            triggerSound = true;
        }
    }
    private void Update(){
        //Debug.Log(fishTag);
        moving = GetComponent<KnifeScript>().moving;


        scoreText.text = "Score: "+ score.ToString();
    }


    private IEnumerator Vanish(GameObject slices){
        //Debug.Log("routine started");
        yield return new WaitForSeconds(1.5f);
        //Debug.Log("routine ended");
        Destroy(slices);
    }

}