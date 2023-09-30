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
<<<<<<< Updated upstream

=======
    private string inputs;
>>>>>>> Stashed changes
    private void Start(){
        cam = Camera.main;
    }
    void Update(){
    //Handles movement/location of swiping the knife
<<<<<<< Updated upstream
    
=======

    //This is for mobile.
>>>>>>> Stashed changes
      if(Input.touchCount > 0){
        touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began){
            swiping = true;
<<<<<<< Updated upstream
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
        

=======
            inputs = "mobile";
        }
        if(touch.phase == TouchPhase.Ended){
          swiping = false;
        }
      }

        if(swiping){
          if(inputs == "mobile"){
            touchPos = touch.position;
            touchPos.z = 3f;
            
          }

          if(inputs == "pc"){
            touchPos = Input.mousePosition;
            touchPos.z = 3f;

          }

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(touchPos);
            
            knife.transform.position = worldPos;
        }
    // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

    //This is for PC
    if(Input.GetMouseButtonDown(0)){
      swiping = true;
      inputs = "pc";
    }

    if(Input.GetMouseButtonUp(0)){
      swiping = false;
    }
 
>>>>>>> Stashed changes
    }
}
