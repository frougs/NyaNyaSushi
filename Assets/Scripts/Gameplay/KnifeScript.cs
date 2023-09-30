using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{
    private Vector3 touchPos;
    private bool swiping;
    private Touch touch;
    [SerializeField] GameObject knife;
    private Camera cam;

    private void Start(){
        cam = Camera.main;
    }
    void Update(){
    //Handles movement/location of swiping the knife
    
      if(Input.touchCount > 0){
        touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began){
            swiping = true;
        }
        if(touch.phase == TouchPhase.Ended){
            swiping = false;
        }
      } 
      if(swiping){
        touchPos = touch.position;
        touchPos.z = 3f;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(touchPos);
        worldPos.x = 0f;
        knife.transform.position = worldPos;
      } 
    }

    private void OnTriggerEnter(Collider other){
        

    }
}
