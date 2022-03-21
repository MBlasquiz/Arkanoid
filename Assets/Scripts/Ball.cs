using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Basic Properties")]
    [SerializeField] private float speed = 5f;
    private Vector2 direction;

    void Start()
    {
        direction = new Vector2(UnityEngine.Random.Range(-3, 3), 1);
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(direction.x * speed * Time.deltaTime,
                            direction.y * speed * Time.deltaTime, 
                            0);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Wall")
        {
            direction.x = -direction.x;
        }
        if(other.tag == "Ceil" || other.tag == "Player" || other.tag == "Block")
        {
            direction.y = -direction.y;
        }
    }
}
