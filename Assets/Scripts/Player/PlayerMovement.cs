using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Basic properties")]
    [Range(4f, 15f)]
    [SerializeField] private float horizontalSpeed = 10f;
    [SerializeField] private Vector2 MinMaxPosition = new Vector2(-5, 5);
    private const float YPosition = -3.75f;

    void Update()
    {
        Move();
        CheckLimitsWorld();
    }

    private void Move()
    {
        var translation = Input.GetAxis("Horizontal") * horizontalSpeed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);
    }

    private void CheckLimitsWorld()
    {
        if (transform.position.x < MinMaxPosition.x)
        {
            transform.position = new Vector3(MinMaxPosition.x, YPosition, 0);
        }
        if (transform.position.x > MinMaxPosition.y)
        {
            transform.position = new Vector3(MinMaxPosition.y, YPosition, 0);
        }
    }
}
