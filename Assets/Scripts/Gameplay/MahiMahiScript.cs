using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MahiMahiScript : MonoBehaviour
{
    [SerializeField] GameObject mahiMahiObj;
    [SerializeField] float warnDelayRange;
    [SerializeField] private float warnTimer;
    [SerializeField] private bool warnPlayer;
    private GameObject spawnedMahi;
    private bool warnStarted;
    [SerializeField] GameObject spawnerObj;
    [SerializeField] float spawnDelayRange;
    [SerializeField] private float spawnTimer;
    [SerializeField] private bool startSpawnCD;
    [SerializeField] GameObject warningText;
    [SerializeField] Animator warningAnim;
    [SerializeField] NewScoreScript score;
    [SerializeField] Material mahiBase;
    [SerializeField] Material mahiOneSlash;
    [SerializeField] Material mahiTwoSlash;
    [SerializeField] Material mahiThreeSlash;
    private Renderer mahiRend;
    private int slashChange;
    private bool spawned;
    void Start()
    {
        MahiDestroyed();
    }

    private void Update(){

        if(spawned && spawnedMahi != null){
            spawnerObj.SetActive(false);
        }

        double mahiDiv = score.mahiDiv;
        if(spawnedMahi != null){
            if(mahiDiv <= 0){
                Debug.Log("Base Mat");
                mahiRend.material = mahiBase;
            }
            if(mahiDiv > 0 && mahiDiv < 0.5){
                mahiRend.material = mahiOneSlash;
                Debug.Log("One Slash Mat");
            }
            if(mahiDiv > 0.5 && mahiDiv < 0.75){
                mahiRend.material = mahiTwoSlash;
                Debug.Log("Two Slash Mat");
            }
            if(mahiDiv >= 0.75){
                mahiRend.material = mahiThreeSlash;
                Debug.Log("Three Slash Mat");
            }
        }


        
        

        if(startSpawnCD){
            spawnTimer -= Time.deltaTime;
            if(spawnTimer <= 0 && spawnedMahi == null && warnPlayer == false){
                StartWarn();
            }
            if(warnPlayer == true){
                warningAnim.SetBool("incoming", true);
                warningText.SetActive(true);
                warnTimer -= Time.deltaTime;
                if(warnTimer <= 0){
                    ClearBelt();
                    SpawnMahiFish();
                    warnPlayer = false;
                    startSpawnCD = false;
                }
            }
        }
    }

    private void StartWarn(){
        spawnerObj.SetActive(false);
        warnStarted = true;
        Random.InitState(System.DateTime.Now.Millisecond);
        Random.State randomizer = Random.state;
        warnTimer = Random.Range(0, warnDelayRange);
        warnPlayer = true;
    }

    private void SpawnMahiFish(){
        spawned = true;
        warningAnim.SetBool("incoming", false);
        //warningText.SetActive(false);
        Debug.Log("Spawning");
        warnPlayer = false;
        spawnedMahi = Instantiate(mahiMahiObj, transform);
        mahiRend = spawnedMahi.GetComponent<Renderer>();
        warnStarted = false;
    }
    public void MahiDestroyed(){
        score.currentMahiSlices = 0;
        spawnerObj.SetActive(true);
        startSpawnCD = true;
        Random.InitState(System.DateTime.Now.Millisecond);
        Random.State randomizer = Random.state;
        spawnTimer = Random.Range(20, spawnDelayRange);
    }
    private void ClearBelt(){
        ConveyorScript[] convObjs = FindObjectsOfType<ConveyorScript>();
        foreach(ConveyorScript obj in convObjs){
            Destroy(obj.gameObject);
        }
    }
}
