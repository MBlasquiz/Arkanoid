using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Levels")]
    [SerializeField] private List<GameObject> Levels;
    [SerializeField] private int currentLevel = 0;
    private const int maxLevel = 2;
    public Action onNextLevel;
    public Action<string> onFinishedGame;

    void Start()
    {
        LoadLevel();
    }

    private void LoadLevel()
    {
        var level = Instantiate(Levels[currentLevel], transform);
        level.GetComponent<LevelController>().onFinishedLevel += NextLevel;
        FindObjectOfType<HealthController>().onGameOver += Restart;
    }

    private void NextLevel()
    {
        CheckWinningCondition();
        
        if (currentLevel < maxLevel)
        {
            StartGame();
            currentLevel++;
        }
    }

    private void CheckWinningCondition()
    {
        if (currentLevel == maxLevel)
        {
            Restart("You Win");
        }
    }

    private void StartGame()
    {
        ClearBlocks();
        onNextLevel?.Invoke();
        LoadLevel();
    }

    private void ClearBlocks()
    {
        for(var childIndex = 0; childIndex < transform.childCount; childIndex++)
        {
            Destroy(transform.GetChild(childIndex).gameObject);
        }
    }

    private void Restart(string text)
    {
        StartCoroutine(NewGame(text));
    }

    private IEnumerator NewGame(string text)
    {
        onFinishedGame?.Invoke(text);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1.5f);
        currentLevel = 0;
        StartGame();
        Time.timeScale = 1;
    }
}
