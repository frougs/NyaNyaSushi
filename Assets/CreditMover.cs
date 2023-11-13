using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditMover : MonoBehaviour
{

    [SerializeField] float creditSpeed;

    void FixedUpdate()
    {
      var creditPos = this.transform.position;
      creditPos.z -= creditSpeed * Time.deltaTime;
      transform.position = creditPos;  
    }
}
