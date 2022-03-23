using System;
using UnityEditor;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [Header("Lifes properties")]
    [SerializeField] private int lifes = 3;
    public Action<int> onLostLife;
    public Action<string> onGameOver;

    private int originalLifes;

    void Start()
    {
        originalLifes = lifes;
        FindObjectOfType<Ball>().onLostBall+=onLostBall;
        FindObjectOfType<GameController>().onFinishedGame += Restore;
        onLostLife?.Invoke(lifes);
    }
    
    private void Restore(string text)
    {
        lifes = originalLifes;
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
