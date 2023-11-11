using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjectScript : MonoBehaviour
{
    public void DisableThis(){
        this.gameObject.SetActive(false);
    }
}
