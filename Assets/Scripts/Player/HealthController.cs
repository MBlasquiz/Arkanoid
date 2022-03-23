using System;
using UnityEditor;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [Header("Lifes properties")]
    [SerializeField] private int lifes = 3;
    public Action<int> onLostLife;
    public Action<string> onGameOver;

    void Start()
    {
        GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>().onLostBall+=onLostBall;
        onLostLife?.Invoke(lifes);
    }
    
    private void onLostBall()
    {
        if(lifes > 0)
        {
            lifes--;
            onLostLife?.Invoke(lifes);

            if(lifes == 0)
            {
                onGameOver?.Invoke("Game Over");
            }
        }
    }
}
