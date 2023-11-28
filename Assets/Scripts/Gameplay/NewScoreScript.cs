using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;
    private bool moving;
    public string fishTag;
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
    [SerializeField] GameObject slicedI;
    [SerializeField] GameObject slicedClam;
    [SerializeField] GameObject slicedEel;
    [SerializeField] GameObject slicedCucumber;
    private GameObject slicedTObj;
    private GameObject slicedSObj;
    private GameObject slicesObj;
    private GameObject slicedRObj;
    private GameObject slicedPowerup;
    private GameObject slicedClamObj;
    private GameObject slicedUObj;
    private GameObject urchinNSObj;
    private GameObject sliceEelObj;
    private GameObject sliceCucumberObj;
    private bool triggerSound;
    [SerializeField] NextOrderScript nextOrder;

    [SerializeField] LivesScript lives;
    [SerializeField] PowerUpScript powerupManager;
    private TextMeshPro mahiSlices;
    public int currentMahiSlices;
    private bool mahiDetect = true;
    [SerializeField] MahiMahiScript mahiScript;
    [SerializeField] GameObject mahiSliceObj;

    [SerializeField] GameObject slicedUrchin;
    [SerializeField] GameObject urchinNoSpikes;


    private GameObject mSliceObj;
    [SerializeField] int mahiNumSlices;
    public int totalMahiSlices;
    [HideInInspector] public double mahiDiv;
    [SerializeField] private bool urchinDetect = false;

    private void Start(){
        sushiTags.Add("Tuna");
        sushiTags.Add("Salmon");
        sushiTags.Add("Clam");
        sushiTags.Add("UrchinNoSpikes");
        sushiTags.Add("Eel");
        score = 0;
    }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Mahi" && mahiDetect == true){
            currentMahiSlices += 1;
            triggerSound = true;
            mahiSlices = other.gameObject.transform.Find("sliceCount").GetComponent<TextMeshPro>();
            mahiSlices.text = currentMahiSlices +" / " +totalMahiSlices;
            if(currentMahiSlices >= totalMahiSlices){
                Destroy(other.gameObject);
                mahiScript.MahiDestroyed();
                mSliceObj = Instantiate(mahiSliceObj, transform);
                Debug.Log(mSliceObj.transform.position);
                StartCoroutine(Vanish(mSliceObj));
            }
            mahiDetect = false;
        }

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
            else if(urchinDetect){
                if(other.gameObject.tag == "UrchinNoSpikes"){
                    Debug.Log("No Spikes");
                    slicedUObj = Instantiate(slicedUrchin, transform);
                    StartCoroutine(Vanish(slicedUObj));
                    Destroy(other.gameObject);
                }
            }
            else if(other.gameObject.CompareTag("Clam")){
                slicedClamObj = Instantiate(slicedClam, transform);
                StartCoroutine(Vanish(slicedClamObj));
            }
            else if(other.gameObject.CompareTag("Eel")){
                sliceEelObj = Instantiate(slicedEel, transform);
                StartCoroutine(Vanish(sliceEelObj));
            }
            if(other.gameObject.tag != "UrchinNoSpikes"){
                Debug.Log(other.gameObject.name);
                Destroy(other.gameObject);
            }
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
            else if(other.gameObject.CompareTag("Clam")){
                slicedClamObj = Instantiate(slicedClam, transform);
                StartCoroutine(Vanish(slicedClamObj));
            }
            else if(urchinDetect){
                if(other.gameObject.tag == "UrchinNoSpikes"){
                    Debug.Log("No Spikes");
                    slicedUObj = Instantiate(slicedUrchin, transform);
                    StartCoroutine(Vanish(slicedUObj));
                    Destroy(other.gameObject);
                }
            }
            else if(other.gameObject.CompareTag("Eel")){
                sliceEelObj = Instantiate(slicedEel, transform);
                StartCoroutine(Vanish(sliceEelObj));
            }
            if(other.gameObject.tag != "UrchinNoSpikes"){
                Debug.Log(other.gameObject.name);
                Destroy(other.gameObject);
            }
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
            Destroy(other.transform.parent.gameObject);
            pufferSource.Play();
            nextOrder.GenerateOrder();
            lives.lives -= 1;
            orders.ClearConveyor();
            triggerSound = true;
        }
        else if(other.gameObject.CompareTag("PowerUp") && moving){
            //other.gameObject.GetComponent<PowerUpScript>().triggerPowerup = true;
            powerupManager.GetComponent<PowerUpScript>().PowerUp(other.gameObject.GetComponent<PowerUpType>().powerUpName);
            triggerSound = true;
            if(other.gameObject.name.Contains("freeze")){
                slicedPowerup = Instantiate(slicedI, transform);
                slicedPowerup.transform.position = other.gameObject.transform.position;
                Destroy(other.gameObject);
                StartCoroutine(Vanish(slicedPowerup));
            }

        }
        else if(other.gameObject.CompareTag("Urchin") && moving){
            Debug.Log("Spawning no spikes");
            urchinDetect = false;
            var urchinPos = other.gameObject.transform.position;
            var urchinRot = other.gameObject.transform.rotation;
            urchinNSObj = Instantiate(urchinNoSpikes, urchinPos, urchinRot);
            Destroy(other.gameObject);
            //Debug.Log("Spawned at: " + urchinNSObj.transform.position);
            StartCoroutine(UrchinDelay());
        }
        else if(other.gameObject.CompareTag("Cucumber") && moving && orders.addon2Number != 0){
            score += 10;
            orders.addon2Number -=1;
            sliceCucumberObj = Instantiate(slicedCucumber, transform);
            StartCoroutine(Vanish(sliceCucumberObj));
            animations.emotion = "excited";
            Destroy(other.gameObject);
            triggerSound = true;
        }
        else if(other.gameObject.CompareTag("Cucumber") && moving && orders.addon2Number <= 0){
            sliceCucumberObj = Instantiate(slicedCucumber, transform);
            StartCoroutine(Vanish(sliceCucumberObj));
            Destroy(other.gameObject);
            triggerSound = true;
            animations.emotion = "sad";
            sweatSystem.Play();
        }
    }
    private void Update(){
        //Debug.Log(fishTag);
        moving = GetComponent<KnifeScript>().moving;

        totalMahiSlices = mahiNumSlices + orders.orderNumber;

        scoreText.text = "Score: "+ score.ToString();

        mahiDiv = (double)currentMahiSlices/totalMahiSlices;


    }


    private IEnumerator Vanish(GameObject sliced){
        //Debug.Log("routine started");
        yield return new WaitForSeconds(1.5f);
        //Debug.Log("routine ended");
        Destroy(sliced);
        //urchinDetect = true;
    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Mahi"){
            mahiDetect = true;
        }
        /*if(other.gameObject.tag == "Urchin"){
            urchinDetect = true;
        }*/
    }
    private IEnumerator UrchinDelay(){
        yield return new WaitForSeconds(0.5f);
        urchinDetect = true;
    }

}