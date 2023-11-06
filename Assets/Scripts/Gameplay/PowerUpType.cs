using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpType : MonoBehaviour
{
   [HideInInspector] enum Type{
        autoComplete,
        timeSlow,
        extraPoints,
        freezeBelt
    };
    [SerializeField] Type type = new Type();
    [HideInInspector] public string powerUpName;

    private void Awake(){
       powerUpName = type.ToString();
    }
}
