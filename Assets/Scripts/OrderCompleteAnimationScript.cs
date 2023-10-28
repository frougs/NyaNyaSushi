using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderCompleteAnimationScript : MonoBehaviour
{
    [SerializeField] Animator completeAnim;
    [HideInInspector] public bool triggerAnim;

    private void Update(){
        if(triggerAnim){
            completeAnim.SetTrigger("animate");
            triggerAnim = false;
        }
    }
    public void EndAnim(){
        completeAnim.ResetTrigger("animate");
    }
}
