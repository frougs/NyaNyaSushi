using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NyakayamaAnimation : MonoBehaviour
{
    private Animator animator;
    [SerializeField] Animator faceAnimator;
    [SerializeField] GameObject knifeObject;
    [HideInInspector] public string emotion;
    [SerializeField] Transform faceObject;
    private string facing;
    private float knifePos;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(emotion != null){
            Debug.Log(emotion);
        }*/
        //Debug.Log(facing);
        
        knifePos = knifeObject.transform.position.z;

        if(knifePos > -1 || knifePos < 1){
            //animator.SetInteger("facing", 0);
            //faceAnimator.SetInteger("face_facing", 0);
            facing = "front";
            
        }
        if(knifePos > 1){
            //animator.SetInteger("facing", -1);
            //faceAnimator.SetInteger("face_facing", 30);
            facing = "right";
            
        }
        if(knifePos < -1){
            //animator.SetInteger("facing", 1);
            //faceAnimator.SetInteger("face_facing", 20);
            facing = "left";
            

        }

        if(facing == "front"){
            animator.SetInteger("facing", 0);
            faceAnimator.SetInteger("face_facing", 0);
            if(emotion == "excited"){
                faceAnimator.SetInteger("face_facing", 3);
            }
            if(emotion == "dizzy"){
                faceAnimator.SetInteger("face_facing", 4);
            }
            if(emotion == "sad"){
                faceAnimator.SetInteger("face_facing", 2);
            }
            if(emotion == "happy"){
                faceAnimator.SetInteger("face_facing", 1);
            }

            StartCoroutine(ResetFace());
        }
        if(facing == "left"){

            animator.SetInteger("facing", 1);
            faceAnimator.SetInteger("face_facing", 30);
            if(emotion == "excited"){
                faceAnimator.SetInteger("face_facing", 31);
            }
            if(emotion == "dizzy"){
                faceAnimator.SetInteger("face_facing", 33);
            }
            if(emotion == "sad"){
                faceAnimator.SetInteger("face_facing", 32);
            }
            if(emotion == "happy"){
                faceAnimator.SetInteger("face_facing", 34);
            }

            StartCoroutine(ResetFace());
        }
        if(facing == "right"){
            animator.SetInteger("facing", -1);
            faceAnimator.SetInteger("face_facing", 20);
            if(emotion == "excited"){
                faceAnimator.SetInteger("face_facing", 24);
            }
            if(emotion == "dizzy"){
                faceAnimator.SetInteger("face_facing", 22);
            }
            if(emotion == "sad"){
                faceAnimator.SetInteger("face_facing", 23);
            }
            if(emotion == "happy"){
                faceAnimator.SetInteger("face_facing", 21);
            }
            StartCoroutine(ResetFace());
        }
    }

    private IEnumerator ResetFace(){
        yield return new WaitForSeconds(1f);
        emotion = null;
    }
}
