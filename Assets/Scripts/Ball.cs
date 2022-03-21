using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Basic Properties")]
    [Range(4f, 10f)]
    [SerializeField] private float speed = 5f;
    [Range(5f, 15f)]
    [SerializeField] private float maxSpeed = 10f;
    [Range(0f, 1f)]
    [SerializeField] private float speedIncrement = 0.25f;
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
        if(other.tag == "Ceil" || other.tag == "Block")
        {
            direction.y = -direction.y;
        }

        if(other.tag == "Player")
        {
            direction.y = -(direction.y);
            var pos = other.ClosestPoint(transform.position).normalized;

            direction.x += pos.x;
            if(speed < maxSpeed)
            {
                speed+=speedIncrement;
            }
        }

    }
}
