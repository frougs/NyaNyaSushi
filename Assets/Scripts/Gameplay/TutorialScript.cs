using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] GameObject tutorialRice;
    [SerializeField] GameObject tutorialTuna;
    [SerializeField] GameObject tutorialPuffer;
    [SerializeField] GameObject tutorialSpawner;
    [SerializeField] GameObject tutorialAfterRice;
    [SerializeField] GameObject tutorialAfterTuna;
    [SerializeField] GameObject tutorialAfterPuffer;
    [SerializeField] GameObject charInfo;
    private GameObject spawnedTutorialRice;
    private GameObject spawnedTutorialTuna;
    private GameObject spawnedTutorialPuffer;
    private bool spawnedRice = false;
    private bool spawnedTuna = false;
    private bool spawnedPuffer = false;

    public void SpawnRice(){
        charInfo.SetActive(false);
        spawnedTutorialRice = Instantiate(tutorialRice, tutorialSpawner.transform.position, Quaternion.identity);
        spawnedRice = true;
    }  
    public void SpawnTuna(){
        charInfo.SetActive(false);
        spawnedTutorialTuna = Instantiate(tutorialTuna, tutorialSpawner.transform.position, Quaternion.identity);
        spawnedTuna = true;
    }
    public void SpawnPuffer(){
        charInfo.SetActive(false);
        spawnedTutorialPuffer = Instantiate(tutorialPuffer, tutorialSpawner.transform.position, Quaternion.identity);
        spawnedPuffer = true;
    }
    private void Update(){
        if(spawnedRice == true && spawnedTutorialRice == null){
            charInfo.SetActive(true);
            tutorialAfterRice.SetActive(true);
        }
        if(spawnedTuna == true && spawnedTutorialTuna == null){
            charInfo.SetActive(true);
            tutorialAfterTuna.SetActive(true);
        }
        if(spawnedPuffer == true && spawnedTutorialPuffer == null){
            charInfo.SetActive(true);
            tutorialAfterPuffer.SetActive(true);
        }
    }

    public void AllowRiceScreen(){
        spawnedRice = false;
    }
    public void AllowTunaScreen(){
        spawnedTuna = false;
    }
    public void AllowPufferScreen(){
        spawnedPuffer = false;
    }
}
