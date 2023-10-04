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
    //[SerializeField] Rigidbody rb;
    private Vector3 oldPos;
    private Vector3 newPos;
    public bool moving;

    private void Start(){
        cam = Camera.main;
    }
    void Update(){

      newPos = transform.position;

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

      float xVel = oldPos.x - newPos.x;
      float yVel = oldPos.y - newPos.y;

      if(xVel != 0 || yVel != 0 ){
        moving = true;
      }
      else{
        moving = false;
      }
    }
    private void OnCollisionEnter(Collision collision)
   {
        if(collision.gameObject.tag == "Sushi" && moving)
        {
            Destroy(collision.gameObject);
        }
   }

   private void FixedUpdate(){
    oldPos = transform.position;
   }
    
}
