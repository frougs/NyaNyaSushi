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
    private string controls;
    private void Start(){
        cam = Camera.main;
    }
    void Update(){
    //Handles movement/location of swiping the knife
      if(Input.touchCount > 0){
        touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began){
            controls = "mobile";
            swiping = true;
        }
        if(touch.phase == TouchPhase.Ended){
          swiping = false;
        }
    // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
      }  

      if(Input.GetMouseButtonDown(0)){
        swiping = true;
        controls = "pc";
      }
      if(Input.GetMouseButtonUp(0)){
        swiping = false;
      }

      if(swiping){
        if(controls == "mobile"){
            touchPos = touch.position;
        }
        if(controls == "pc"){
          touchPos = Input.mousePosition;
        }
        touchPos.z = 3f;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(touchPos);
        knife.transform.position = worldPos;
      }
    }
    
}
