using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallGrowinhHole : MonoBehaviour
{
    [SerializeField] private GrowHole growHole;

    private void OnTriggerEnter(Collider other)
    { 
        Debug.Log("OBJECT FOND");
        if (other.CompareTag("Player"))   
        {
            StartCoroutine(growHole.StartGrowing());
            Debug.Log("PLAYER FPUND");
        }
    }
}
