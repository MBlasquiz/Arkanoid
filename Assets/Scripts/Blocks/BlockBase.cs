using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBase : MonoBehaviour
{
    [Header ("Basic Properties")]
    [SerializeField] private int points;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Ball")
        {
            Destroy(gameObject);
        }
    }
}
