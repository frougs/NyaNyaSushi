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
    void Start()
    {
        MahiDestroyed();
    }

    /*private void Update(){
        if(spawnMahi){
            SpawnMahiFish();
            spawnMahi = false;
        }
    }*/

    private void Update(){
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
        warningAnim.SetBool("incoming", false);
        //warningText.SetActive(false);
        Debug.Log("Spawning");
        warnPlayer = false;
        spawnedMahi = Instantiate(mahiMahiObj, transform);
        warnStarted = false;
    }
    public void MahiDestroyed(){
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
