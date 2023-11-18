using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    private Vector2 velocityTest;
    private float checkPosDelay = 1f;
    [SerializeField] TextMeshProUGUI debugging;
    private Vector3 lastPos;
    private Rigidbody rb;
    private Vector3 worldPos;

    private void Start(){
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }
    void Update(){
      //debugging.text = moving.ToString();
      checkPosDelay -= Time.deltaTime;
      /*if(transform.hasChanged){
        moving = true;
        transform.hasChanged = false;
      }
      else{
        moving = false;
      }*/


      //newPos = touchPos;

    //Handles movement/location of swiping the knife
      if(Input.touchCount > 0){
        touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began){
            controls = "mobile";
            swiping = true;
            //moving = true;
        }
        if(touch.phase == TouchPhase.Ended){
          swiping = false;
          //moving = false;
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
        worldPos = Camera.main.ScreenToWorldPoint(touchPos);
        //knife.transform.position = worldPos;
        rb.MovePosition(worldPos);
      }

      /*float xVel = Time.deltaTime * (oldPos.x - newPos.x);
      float yVel = Time.deltaTime * (oldPos.y - newPos.y);
      velocityTest = new Vector2(xVel, yVel).normalized;

      if(velocityTest.x != 0 || velocityTest.y != 0 ){
        moving = true;
      }
      else{
        moving = false;
      }*/

      /*if(transform.position != lastPos){
        moving = true;
      }
      else{
        moving = false;
      }

      lastPos = transform.position;*/
      if(!rb.IsSleeping()){
        moving = true;
      }
      else{
        moving = false;
      }

    }
    /*private void OnTriggerEnter(Collider collision)
   {
        if(collision.gameObject.tag == "Sushi" && moving)
        {
            Destroy(collision.gameObject);
        }
   }*/

   private void FixedUpdate(){

    
      /*lastPos = transform.position;
    if(checkPosDelay <= .8){
      oldPos = touchPos;
      if(checkPosDelay <= 0){
        if(oldPos != touchPos){
          //Debug.Log("MOVING");
        }
        else{
          //Debug.Log("NOT MOVING");
        }
        checkPosDelay = 1f;
      }
      
    }*/

   }



    
}
