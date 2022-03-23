using System;
using UnityEditor;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [Header("Lifes properties")]
    [SerializeField] private int lifes = 3;
    public Action<int> onLostLife;
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
                Debug.Log("Game Over");
                #if UNITY_EDITOR
                if(EditorApplication.isPlaying) 
                {
                    UnityEditor.EditorApplication.isPlaying = false;
                }
                #else
                Application.Quit();
                #endif
            }
        }
    }
}
