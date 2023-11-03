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
    [SerializeField] GameObject slicedT;
    [SerializeField] GameObject slicedS;
    [SerializeField] GameObject slicedR;
    private GameObject slicedTObj;
    private GameObject slicedSObj;
    private GameObject slicesObj;
    private GameObject slicedRObj;
    private bool triggerSound;
    [SerializeField] NextOrderScript nextOrder;

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
            if(other.gameObject.CompareTag("Salmon")){
                var slicedSpawn = other.gameObject.transform.Find("slicedSSpawn");
                Debug.Log("Spawning sliced Salmon");
                slicedSObj = Instantiate(slicedS, transform);
                StartCoroutine(Vanish(slicedSObj));
            }
            else if(other.gameObject.CompareTag("Tuna")){
                var slicedSpawn = other.gameObject.transform.Find("slicedTSpawn");
                Debug.Log("Spawning sliced Tuna");
                slicedTObj = Instantiate(slicedT, transform);
                StartCoroutine(Vanish(slicedTObj));
            }
            Destroy(other.gameObject);
            triggerSound = true;
        }
        else if (sushiTags.Contains(other.gameObject.tag.ToString()) && moving && other.gameObject.tag.ToString() != fishTag || sushiTags.Contains(other.gameObject.tag.ToString()) && moving && other.gameObject.tag.ToString() == fishTag && orders.fishNumber == 0){
            //score -= 5;
            animations.emotion = "sad";
            sweatSystem.Play();
            if(other.gameObject.CompareTag("Salmon")){
                Debug.Log("Spawning sliced Salmon");
                var slicedSpawn = other.gameObject.transform.Find("slicedSSpawn");
                slicedSObj = Instantiate(slicedS, transform);
                StartCoroutine(Vanish(slicedSObj));
            }
            else if(other.gameObject.CompareTag("Tuna")){
                Debug.Log("Spawning sliced Tuna");
                var slicedSpawn = other.gameObject.transform.Find("slicedTSpawn");
                slicedTObj = Instantiate(slicedT, transform);
                StartCoroutine(Vanish(slicedTObj));
            }
            Destroy(other.gameObject);
            triggerSound = true;
        }

        if(other.gameObject.CompareTag("Rice") && moving && orders.riceNumber != 0){
            score +=10;
            orders.riceNumber -= 1;
            slicedRObj = Instantiate(slicedR, transform);
            StartCoroutine(Vanish(slicedRObj));
            animations.emotion = "excited";
            Destroy(other.gameObject);
            triggerSound = true;
        }
        else if(other.gameObject.CompareTag("Rice") && moving && orders.riceNumber <= 0){
           // score -= 5;
           slicedRObj = Instantiate(slicedR, transform);
           StartCoroutine(Vanish(slicedRObj));
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
            nextOrder.GenerateOrder();
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


    private IEnumerator Vanish(GameObject sliced){
        //Debug.Log("routine started");
        yield return new WaitForSeconds(1.5f);
        //Debug.Log("routine ended");
        Destroy(sliced);
    }

}